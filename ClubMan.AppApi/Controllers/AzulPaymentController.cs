using System.Text;
using ClubMan.AppApi.Infrastructure;
using ClubMan.Shared.Dto;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

// public static class AzulPaymentPagePaymentSettings
// {
//     public static string MerchantId { get; set; }  = "39038540035";
//     public static string MerchantName { get; set; }  = "Club Naútico Santo Domingo";
//     public static string MerchantType { get; set; }  = "E-COMMERCE";
//     public static string CurrencyCode { get; set; }  = "$";
//     public static string AuthKey { get; set; }  = "asdhakjshdkjasdasmndajksdkjaskldga8odya9d8yoasyd98asdyaisdhoaisyd0a8sydoashd8oasydoiahdpiashd09ayusidhaos8dy0a8dya08syd0a8ssdsax";
//     public static bool UseSandbox { get; set; }  = true;
//     public static String SandboxServiceUrl { get; set; }  = "https://pruebas.azul.com.do/paymentpage/Default.aspx";
//     public static String ServiceUrl { get; set; }  = "https://pruebas.azul.com.do/paymentpage/Default.aspx";
// }

[AllowAnonymous]
[Route("api/[controller]")]
public class AzulPaymentController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<AzulPaymentController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AzulPaymentController(IHttpClientFactory factory, ILogger<AzulPaymentController> logger,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async  Task<IActionResult> PostPayment(PaymentDto dto)
    {

        var empresas = await _http.GetFromJsonAsync<List<Empresa>>($"api/Empresa");
        var _empresa = empresas.First();

        var result = await _http.PostAsJsonAsync("api/AzulPayment", dto);
        
        result.EnsureSuccessStatusCode();

        var cobro = await result.Content.ReadFromJsonAsync<Cobro>();

        var baseUrl ="https://clubmanapi.barolit.net/api"; // "http://nauticoapi.barolit.net:85/api"; //  
        
        var responseRedirectUrl = $"{baseUrl}/AzulPayment/PaymentResult";
        
        var data = new List<KeyValuePair<String, String>>()
        {
            new("MerchantId", _empresa.MerchantId),
            new("MerchantName", _empresa.MerchantName),
            new("MerchantType", _empresa.MerchantType),
            new("CurrencyCode", _empresa.CurrencyCode),
            new("OrderNumber", $"{cobro.Id:00000000}"),
            new("Amount", Convert.ToInt32( cobro.TotalPago * 100) .ToString()),
            new("Itbis", "000" ),
            new("ApprovedUrl", responseRedirectUrl),
            new("DeclinedUrl", responseRedirectUrl),
            new("CancelUrl", responseRedirectUrl),
            new("UseCustomField1", "0"),
            new("CustomField1Label", string.Empty),
            new("CustomField1Value", string.Empty),
            new("UseCustomField2", "0"),
            new("CustomField2Label", string.Empty),
            new("CustomField2Value", string.Empty)
        };
        // Build AuthHash
        var sb = new StringBuilder();
        foreach (var dataItem in data)
        {
            sb.Append(dataItem.Value);
        }
        sb.Append(_empresa.AuthKey);

        var authHash = string.Empty;

        byte[] joinedBytes = Encoding.UTF8.GetBytes(sb.ToString());
        byte[] keyBytes = Encoding.UTF8.GetBytes(_empresa.AuthKey);

        using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(keyBytes))
        {
            byte[] hashValue = hmac.ComputeHash(joinedBytes);
            for (int i = 0; i < hashValue.Length; i++)
            {
                authHash += string.Format("{0:x2}", hashValue[i]);
            }
        }

        data.Add(new KeyValuePair<string, string>("AuthHash", authHash));

        // POST Redirect
        var post = new AzulRemotePost(_httpContextAccessor)
        {
            FormName = "azulpaymentpage",
            Url = _empresa.UseSandbox ? _empresa.SandboxServiceUrl : _empresa.ServiceUrl,
            Method = "POST",
            NewInputForEachValue = false,
            AcceptCharset = "utf-8"
        };

        foreach (var item in data)
        {
            post.Add(item.Key, item.Value);// WebUtility.UrlEncode(item.Value));
        }

        post.Post();
        return Ok();
    }
    
    [HttpGet("PaymentResult")]
    [HttpPost("PaymentResult")]
    public async Task<IActionResult> PaymentResult()
    {
        try
        {
            //define local function to get a value from the request Form or from the Query parameters
            string GetValue(string key) =>
                Request.HasFormContentType && Request.Form.TryGetValue(key, out var value)
                ? value.ToString()
                : Request.Query[key].ToString()
                ?? string.Empty;

            //ensure this payment method is active
            if (!Request.Query.Any())
            {
                _logger.LogCritical("Invalid Request: {Request}",Request.ToString());
                return RedirectToAction("Aborted", "AzulPaymentResult", "Error de conexión, favor verificar y reintentar.");
            }

            var customOrderNumber = GetValue("OrderNumber");

            var result = await _http.GetAsync($"api/Cobro/{customOrderNumber}");

            if (!result.IsSuccessStatusCode)
            {
                _logger.LogCritical("Cobro not found: {Cobro}",customOrderNumber);
                return RedirectToAction("Aborted", "AzulPaymentResult", "Error de conexión e integridad, favor verificar y reintentar.");
            }

            var cobro = await result.Content.ReadFromJsonAsync<Cobro>();

            //save request info as order note for debug purposes
            var info = new StringBuilder();
            info.AppendLine("Azul payment page IPN:");
            if (Request.HasFormContentType && Request.Form.Keys.Any())
            {
                //form parameters
                foreach (var key in Request.Form.Keys)
                {
                    info.AppendLine($"{key}: {Request.Form[key]}");
                }
            }
            else
            {
                //query parameters
                info.AppendLine(Request.QueryString.ToString());
            }

            cobro.Mensaje = info.ToString();

            // TODO: Validate return hash 
            // if (false && _azulPaymentPageSettings.UseSandbox)
            // {
            //
            //     var sb = new StringBuilder();
            //     sb.Append(getValue("OrderNumber"));
            //     sb.Append(getValue("Amount"));
            //     sb.Append(getValue("AuthorizationCode"));
            //     sb.Append(getValue("DateTime"));
            //     sb.Append(getValue("ResponseCode"));
            //     sb.Append(getValue("IsoCode"));
            //     sb.Append(getValue("ResponseMessage"));
            //     sb.Append(getValue("ErrorDescription"));
            //     sb.Append(getValue("RRN"));
            //     sb.Append(getValue(_azulPaymentPageSettings.AuthKey));
            //
            //     byte[] keyBytes = Encoding.Unicode.GetBytes(_azulPaymentPageSettings.AuthKey);
            //     byte[] joinedBytes = Encoding.Unicode.GetBytes(sb.ToString());
            //
            //     var localHash = string.Empty;
            //
            //     using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(keyBytes))
            //     {
            //         byte[] hashValue = hmac.ComputeHash(joinedBytes);
            //         for (int i = 0; i < hashValue.Length; i++)
            //         {
            //             localHash += string.Format("{0:x2}", hashValue[i]);
            //         }
            //     }
            //
            //     var receivedHash = getValue("AuthHash");
            //
            //     if (localHash.ToUpperInvariant() != receivedHash.ToUpperInvariant())
            //     {
            //         _orderService.InsertOrderNote(new OrderNote
            //         {
            //             OrderId = order.Id,
            //             Note = "Hash validation failed",
            //             DisplayToCustomer = false,
            //             CreatedOnUtc = DateTime.UtcNow
            //         });
            //
            //         return RedirectToRoute("OrderDetails", new { orderId = order.Id });
            //     }
            // }
            
            var responseMessage = GetValue("ResponseMessage");
            var cardNumber = GetValue("CardNumber");

            if (responseMessage.ToUpperInvariant() == "APROBADA")
            {
                cobro.Estatus = 1;
                cobro.Mensaje = $"{responseMessage}";
                cobro.NumeroTarjeta = cardNumber;
                cobro.NumeroConfirmacion = GetValue("AuthorizationCode");
                cobro.ConfirmadoEn=DateTime.Now;
            }
            else
            {
                cobro.Estatus = -1;
                cobro.Mensaje = $"AZUL: {responseMessage} : {GetValue("ErrorDescription")}";
                cobro.NumeroTarjeta = cardNumber;
            }

            result = await _http.PutAsJsonAsync("api/Cobro", cobro);
            result.EnsureSuccessStatusCode();

            return RedirectToAction(cobro.Estatus == 1 ? "Approved" : "Rejected", "AzulPaymentResult", cobro);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,"Exception: {ExceptionMessage}", exception.Message);
            return RedirectToAction("Aborted", "AzulPaymentResult", "Error interno.");
        }
    }
}