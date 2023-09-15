using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class InvitacionesController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<InvitacionesController> _logger;

    public InvitacionesController(IHttpClientFactory factory, ILogger<InvitacionesController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }
    
    
    [HttpGet("solicitud/{solicitudId:Guid}", Name = "GetBySolicitudId")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetBySolicitudId(Guid solicitudId)
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<InvitacionDeSocio>>($"api/Invitaciones/solicitud/{solicitudId}");
    }
    
    
    [HttpGet("socio/{socioId:long}", Name = "GetInvitacionesPendientesDeSocio")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetPendientesDeSocio(long socioId)
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<InvitacionDeSocio>>($"api/Invitaciones/socio/{socioId}");
    }
    
    
}