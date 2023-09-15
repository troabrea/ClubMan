using ClubMan.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;
[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class ErpController : TenantController
{
    private readonly HttpClient _http;

    public ErpController(IHttpClientFactory factory,  ILogger<CarnetController> logger,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
    }
    
    [HttpGet("EstadoDeCuenta/{socioId}", Name = "GetEstadoBySocioId")]
    [Produces(typeof(IEnumerable<FacturaDto>))]
    public async Task<IActionResult> GetEstadoCuentaBySocioId(long socioId)
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<FacturaDto>>($"api/Erp/EstadoDeCuenta/{socioId}");
        return Ok(result);
    }
}