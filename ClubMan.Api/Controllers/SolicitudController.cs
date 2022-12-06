using ClubMan.Api.Services;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class SolicitudController : TenantController
{
    private readonly ILogger<SolicitudController> _logger;

    public SolicitudController(ILogger<SolicitudController> logger, IDocumentStore store,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSolicitudes")]
    public async Task<IReadOnlyList<Solicitud>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Solicitud>().Where(x => x.EstatusSolicitud == EstatusSolicitud.Recibida || x.EstatusSolicitud == EstatusSolicitud.Sometida || x.EstatusSolicitud == EstatusSolicitud.Pospuesto).ToListAsync();
    }

    [HttpGet( "{solicitudId:long}", Name = "GetSolicitud")]
    public async Task<Solicitud> GetById(long solicitudId)
    {
        using var session = _store.OpenSession(TenantId);
        return await session.LoadAsync<Solicitud>(solicitudId);
    }
    
    [HttpGet("all", Name = "GetAllSolicitudes")]
    public async Task<IReadOnlyList<Solicitud>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Solicitud>().ToListAsync();
    }

    [HttpPost("updateMainPhoto", Name = "UpdateMainPhoto")]
    public async Task<IActionResult> PostMainPhoto([FromBody] ActualizarFotoPrincipalEvent actualizarFotoPrincipalEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(actualizarFotoPrincipalEvent.SolicitudId);
        if (solicitud == null)
        {
            return NotFound();
        }
        solicitud.FotoSocioUrl = actualizarFotoPrincipalEvent.FotoUrl;
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("updateSecondaryPhoto", Name = "UpdateSecondaryPhoto")]
    public async Task<IActionResult> PostSecondayPhoto([FromBody] ActualizarFotoDependienteEvent actualizarFotoDependienteEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(actualizarFotoDependienteEvent.SolicitudId);
        if (solicitud == null)
        {
            return NotFound();
        }

        var dep = solicitud.Dependientes.FirstOrDefault(x => x.Id == actualizarFotoDependienteEvent.DependienteId);
        if (dep == null)
        {
            return NotFound();
        }
        
        dep.FotoUrl = actualizarFotoDependienteEvent.FotoUrl;
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost(Name = "AddOrUpdateSolicitud")]
    public async Task<IActionResult> Post([FromBody] Solicitud solicitud)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("submit", Name = "SometerSolicitud")]
    public async Task<IActionResult> PostReject([FromBody] SometerSolicitudEvent someterEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(someterEvent.SolicitudId);
        solicitud.Revisiones ??= new List<Revision>();
        solicitud.Revisiones.Add( new Revision()
        {
            FechaSometida = someterEvent.FechaSometimiento,
            EstatusRevision = EstatusRevision.Pendiente,
            Observaciones = "",
            CompletadaPor = "",
            SometidaPor = someterEvent.UserName
        });
        solicitud.EstatusSolicitud = EstatusSolicitud.Sometida;
        solicitud.UltimoSometimiento = someterEvent.FechaSometimiento; 
        //
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("postpone", Name = "PostponerSolicitud")]
    public async Task<IActionResult> PostPostone([FromBody] PostponerSolicitudEvent postponerEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(postponerEvent.SolicitudId);
        var revison = solicitud.Revisiones.First(x => x.EstatusRevision == EstatusRevision.Pendiente);
        //
        revison.Observaciones = postponerEvent.Observaciones;
        revison.FechaRevision = postponerEvent.FechaRevision;
        revison.EstatusRevision = EstatusRevision.Pospuesto;
        revison.CompletadaPor = postponerEvent.UserName;
        //
        solicitud.EstatusSolicitud = EstatusSolicitud.Pospuesto;
        solicitud.UltimaRevision = postponerEvent.FechaRevision; 
        //
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("reject", Name = "RechazarSolicitud")]
    public async Task<IActionResult> PostReject([FromBody] RechazarSolicitudEvent rechazarEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(rechazarEvent.SolicitudId);
        var revison = solicitud.Revisiones.First(x => x.EstatusRevision == EstatusRevision.Pendiente);
        //
        revison.Observaciones = rechazarEvent.Observaciones;
        revison.FechaRevision = rechazarEvent.FechaRevision;
        revison.EstatusRevision = EstatusRevision.Rechazado;
        revison.CompletadaPor = rechazarEvent.UserName;
        //
        solicitud.EstatusSolicitud = EstatusSolicitud.Rechazado;
        solicitud.UltimaRevision = rechazarEvent.FechaRevision; 
        //
        session.Store(solicitud);
        await session.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("approve", Name = "AprobarSolicitud")]
    public async Task<IActionResult> PostApproval([FromBody] AprobarSolicitudEvent aprobarEvent, [FromServices] ICarnetService carnetService)
    {
        using var session = _store.OpenSession(TenantId);
        var solicitud = await session.LoadAsync<Solicitud>(aprobarEvent.SolicitudId);
        var revison = solicitud.Revisiones.First(x => x.EstatusRevision == EstatusRevision.Pendiente);
        //
        revison.Observaciones = aprobarEvent.Observaciones;
        revison.FechaRevision = aprobarEvent.FechaRevision;
        revison.EstatusRevision = EstatusRevision.Rechazado;
        revison.CompletadaPor = aprobarEvent.UserName;
        revison.NumeroAprobacion = aprobarEvent.NumeroAprobacion;
        revison.CantidadAcciones = aprobarEvent.CantidadAcciones;
        revison.Valoracciones = aprobarEvent.Valoraciones;
        //
        solicitud.EstatusSolicitud = EstatusSolicitud.Aprobado;
        solicitud.UltimaRevision = aprobarEvent.FechaRevision;
        //
        var socio = Socio.FromSolicitud(solicitud, aprobarEvent);
        //x
        session.Store(solicitud);
        session.Store(socio);
        //
        carnetService.CreateInitialCarnets(session, socio);
        //
        await session.SaveChangesAsync();
        return Ok();
    }
}