using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class InvitacionesController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<InvitacionesController> _logger;

    public InvitacionesController(ClubManContext db, ILogger<InvitacionesController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }
    
    [HttpGet("{invitacionId:Guid}", Name = "GetById")]
    public async Task<InvitacionDeSocio> GetById(Guid invitacionId)
    {
        var result = await _db.FindAsync<InvitacionDeSocio>(invitacionId);
        return result;
    }
    
    [HttpGet("solicitud/{solicitudId:Guid}", Name = "GetBySolicitudId")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetBySolicitudId(Guid solicitudId)
    {
        var result = await _db.InvitacionesDeSocio.Where( x => x.SolicitudId == solicitudId).ToListAsync();
        return result;
    }
    
    [HttpGet("identidad/{numeroIndentidad}", Name = "GetByNumeroIdentidad")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetById(string numeroIndentidad)
    {
        var result = await _db.InvitacionesDeSocio.Where(x => x.NumeroIdentidad == numeroIndentidad && x.Estatus == EstatusInvitacion.Sometida).ToListAsync();
        return result;
    }
    
    [HttpGet("socio/{socioId:long}", Name = "GetInvitacionesPendientesDeSocio")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetPendientesDeSocio(long socioId)
    {
        var result = await _db.InvitacionesDeSocio
            .Where(x => x.SocioId == socioId && x.Estatus == EstatusInvitacion.Sometida).ToListAsync();
        return result;
    }
    
    [HttpGet("socio/recientes/{socioId:long}", Name = "GetInvitacionesRecientesDeSocio")]
    public async Task<IReadOnlyList<InvitacionDeSocio>> GetRecientesDeSocio(long socioId)
    {
        var result = await _db.InvitacionesDeSocio
            .Where(x => x.SocioId == socioId).OrderByDescending(x => x.FechaHora).ToListAsync();
        return result;
    }
    
    [HttpPost(Name = "AddOrUpdateInvitacion")]
    public async Task<IActionResult> AddOrUpdateInvitacion([FromBody] InvitacionDeSocio invitacionDeSocio)
    {
        _db.Add(invitacionDeSocio);
        await _db.SaveChangesAsync();
        return NoContent();
    }
    
}