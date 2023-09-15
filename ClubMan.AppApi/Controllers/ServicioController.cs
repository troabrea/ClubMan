using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class ServicioController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<ServicioController> _logger;

    public ServicioController(IHttpClientFactory factory, ILogger<ServicioController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetServicios")]
    public async Task<IReadOnlyList<Servicio>> Get()
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<Servicio>>("api/Servicio");
    }
    
}