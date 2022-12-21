using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class InvitacionesController : TenantController
{
    private readonly ILogger<InvitacionesController> _logger;

    public InvitacionesController(ILogger<InvitacionesController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }
    
    [HttpGet("{invitacionId:Guid}", Name = "GetById")]
    public async Task<InvitacionDeSocio> GetById(Guid invitacionId)
    {
        using var session = _store.OpenSession(TenantId);
        var result = await session.LoadAsync<InvitacionDeSocio>(invitacionId);
        return result;
    }
    
    [HttpGet("identidad/{numeroIndentidad}", Name = "GetByNumeroIdentidad")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetById(string numeroIndentidad)
    {
        using var session = _store.OpenSession(TenantId);
        var result = await session.Query<InvitacionDeSocio>().Where(x => x.NumeroIdentidad == numeroIndentidad && x.Estatus == EstatusInvitacion.Sometida).ToListAsync();
        return result;
    }
    
    [HttpGet("socio/{socioId:long}", Name = "GetInvitacionesPendientesDeSocio")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetPendientesDeSocio(long socioId)
    {
        using var session = _store.OpenSession(TenantId);
        var result = await session.Query<InvitacionDeSocio>()
            .Where(x => x.SocioId == socioId && x.Estatus == EstatusInvitacion.Sometida).ToListAsync();
        return result;
    }
    
    [HttpGet("socio/recientes/{socioId:long}", Name = "GetInvitacionesRecientesDeSocio")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetRecientesDeSocio(long socioId)
    {
        using var session = _store.OpenSession(TenantId);
        var result = await session.Query<InvitacionDeSocio>()
            .Where(x => x.SocioId == socioId).OrderByDescending(x => x.FechaHora).ToListAsync();
        return result;
    }
    
    [HttpPost(Name = "AddOrUpdateInvitacion")]
    public async Task<IActionResult> AddOrUpdateInvitacion([FromBody] InvitacionDeSocio invitacionDeSocio)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(invitacionDeSocio);
        await session.SaveChangesAsync();
        return NoContent();
    }
    
}