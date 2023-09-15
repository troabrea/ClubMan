using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class VisitasController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<VisitasController> _logger;

    public VisitasController(IHttpClientFactory factory, ILogger<VisitasController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpPost("socio/{porteroId:Guid}", Name = "PostVisitaSocio")]
    public async Task<IActionResult> PostVisitaSocio(Carnet carnet, Guid porteroId)
    {
        var result = await _http.PostAsJsonAsync($"api/Visitas/socio/{porteroId}", carnet);
        result.EnsureSuccessStatusCode();        
        return Ok();
    }
    
    [HttpPost("socio/adicional/{porteroId:Guid}", Name = "PostVisitaAdicionalSocio")]
    public async Task<IActionResult> PostVisitaAdicionalSocio(VisitaAdicionalSocioRegistradaEvent visitaEvent, Guid porteroId)
    {

        var result = await _http.PostAsJsonAsync($"api/Visitas/socio/adicional/{porteroId.ToString()}", visitaEvent);
        result.EnsureSuccessStatusCode();
        return Ok();
    }
    
    [HttpPost("socio/invitacion/{invitacionId:Guid}/{porteroId:Guid}", Name = "PostVisitaInvitadoSocio")]
    public async Task<IActionResult> PostVisitaInvitadoSocio(Guid invitacionId, Guid porteroId)
    {
        var result = await _http.PostAsync($"api/Visitas/socio/invitacion/{invitacionId.ToString()}/{porteroId.ToString()}", null);
        result.EnsureSuccessStatusCode();
        return Ok();
    }

    
    [HttpGet("socio/{socioId:long}", Name = "GetVisitasSocioActual")]
    public  async Task<VisitasSocio> GetVisitasSocioActual(long socioId)
    {
        return await _http.GetFromJsonAsync<VisitasSocio>($"api/Visitas/socio/{socioId}");
    }


    [HttpPost("manual")]
    [Produces(typeof(VisitaManual))]
    public async Task<IActionResult> PostVisitaManual(VisitaManual visitaManual)
    {
        var result = await _http.PostAsJsonAsync($"api/Visitas/manual", visitaManual);
        result.EnsureSuccessStatusCode();
        return Ok();
    }
    
}