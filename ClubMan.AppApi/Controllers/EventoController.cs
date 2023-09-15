using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class EventoController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<EventoController> _logger;

    public EventoController(IHttpClientFactory factory, ILogger<EventoController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }
    
    [HttpGet("{socioId}", Name = "GetEventosSocio")]
    public async Task<IEnumerable<EventoViewModel>> GetSocio(long socioId)
    {
        return await _http.GetFromJsonAsync<List<EventoViewModel>>($"api/Evento/{socioId}");
    }
    
    [HttpGet("hoy", Name = "GetEventosHoy")]
    public async Task<IEnumerable<EventoViewModel>> GetEventosDeHoy()
    {
        return await _http.GetFromJsonAsync<List<EventoViewModel>>($"api/Evento/hoy");
    }
    
    [HttpGet("byId/{eventoId}", Name = "GetEventoById")]
    public async Task<EventoViewModel> GetById(long eventoId)
    {
        return await _http.GetFromJsonAsync<EventoViewModel>($"/evento/byId/{eventoId}");
    }
    
    [HttpPost(Name = "AddEvento")]
    public async Task<IActionResult> Post([FromBody] EventoDeSocio evento)
    {
        var result = await _http.PostAsJsonAsync("api/Evento", evento);
        result.EnsureSuccessStatusCode();
        //
        return Ok();
    }
    
}