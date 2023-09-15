using System.Text;
using ClubMan.AppApi.Model;
using ClubMan.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class SmsController : TenantController
{
    private readonly ILogger<SmsController> _logger;
    private readonly IHttpClientFactory _clientFactory;
    private readonly AppSettings _appSettings;
    
    public SmsController(IConfiguration configuration, ILogger<SmsController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _appSettings = configuration.GetSection(AppSettings.ConfigKey).Get<AppSettings>();    
    }
    [HttpPost("SolicitarLoginPin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SolicitarLoginPin(SmsDto smsDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        //
        var req = new SmsRequestDto()
        {
            ClientKey = _appSettings.SmsApiKey,
            ClientId = _appSettings.SmsPlataform,
            Celular = smsDto.Celular,
            Mensaje = smsDto.Mensaje,
            Referencia = "LoginPin_" + Guid.NewGuid().ToString(),
        };
        var httpClient = _clientFactory.CreateClient();
        httpClient.BaseAddress = new Uri( _appSettings.SmsApiUrl );
        var json = System.Text.Json.JsonSerializer.Serialize(req);
        _logger.LogInformation(json);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(
            "SmsInternal", data);

        response.EnsureSuccessStatusCode();
        
        return Ok();
    }
}