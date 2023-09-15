using ClubMan.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class ActividadController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<ActividadController> _logger;

    public ActividadController(IHttpClientFactory factory, ILogger<ActividadController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetActividades")]
    public async Task<IEnumerable<ActividadViewModel>> Get()
    {
        return await _http.GetFromJsonAsync<IEnumerable<ActividadViewModel>>("api/Actividad");
    }
    
    [HttpGet("hoy",Name = "GetActividadesDeHoy")]
    public async Task<IEnumerable<ActividadViewModel>> GetToday()
    {
        return await _http.GetFromJsonAsync<IEnumerable<ActividadViewModel>>("api/Actividad/hoy");
    }
    
}