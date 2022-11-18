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
        if (solicitud.Revisiones == null)
        {
            solicitud.Revisiones = new List<Revision>();
        }
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
}