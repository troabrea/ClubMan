using System.Runtime.Intrinsics.X86;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using ClubMan.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class SolicitudController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<SolicitudController> _logger;

    public SolicitudController(ClubManContext db, ILogger<SolicitudController> logger,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetSolicitudes")]
    public async Task<IReadOnlyList<Solicitud>> Get()
    {
        return await _db.Solicitudes.Where(x => x.EstatusSolicitud == EstatusSolicitud.Recibida || x.EstatusSolicitud == EstatusSolicitud.Sometida || x.EstatusSolicitud == EstatusSolicitud.Pospuesto).ToListAsync();
    }

    [HttpGet( "{solicitudId:long}", Name = "GetSolicitud")]
    public async Task<Solicitud> GetById(long solicitudId)
    {
        return await _db.FindAsync<Solicitud>(solicitudId);
    }
    
    [HttpGet("beneficiario/{beneficiarioId}", Name = "GetBeneficiarioSolicitudes")]
    public async Task<IReadOnlyList<Solicitud>> GetByBeneficiario(string beneficiarioId)
    {
        return await _db.Solicitudes.Where(x => x.NumeroIdentidad == beneficiarioId && ( x.EstatusSolicitud == EstatusSolicitud.Aprobado || x.EstatusSolicitud == EstatusSolicitud.Rechazado ) ).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllSolicitudes")]
    public async Task<IReadOnlyList<Solicitud>> GetAll()
    {
        return await _db.Solicitudes.ToListAsync();
    }

    [HttpPost("updateMainPhoto", Name = "UpdateMainPhoto")]
    public async Task<IActionResult> PostMainPhoto([FromBody] ActualizarFotoPrincipalEvent actualizarFotoPrincipalEvent)
    {
        var solicitud = await _db.FindAsync<Solicitud>(actualizarFotoPrincipalEvent.SolicitudId);
        if (solicitud == null)
        {
            return NotFound();
        }
        solicitud.FotoSocioUrl = actualizarFotoPrincipalEvent.FotoUrl;
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("updateSecondaryPhoto", Name = "UpdateSecondaryPhoto")]
    public async Task<IActionResult> PostSecondayPhoto([FromBody] ActualizarFotoDependienteEvent actualizarFotoDependienteEvent)
    {
        var solicitud = await _db.FindAsync<Solicitud>(actualizarFotoDependienteEvent.SolicitudId);
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
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost(Name = "AddSolicitud")]
    public async Task<IActionResult> Post([FromBody] Solicitud solicitud)
    {
        _db.Add(solicitud);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateSolicitud")]
    public async Task<IActionResult> Put([FromBody] Solicitud solicitud)
    {
        var entry = _db.Entry(solicitud);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
            // -- Embarcaciones
            await _db.Database.ExecuteSqlRawAsync($"DELETE Solcitud_Embarcaciones WHERE SolicitudId = {solicitud.Id}");
            foreach (var rec in solicitud.Embarcaciones)
            {
                var embarcacionEntry = entry.Collection(s => s.Embarcaciones).FindEntry(rec);
                if (embarcacionEntry != null)
                {
                    embarcacionEntry.State = EntityState.Added;
                }
            }
            await _db.SaveChangesAsync();
            // -- Secundadores
            await _db.Database.ExecuteSqlRawAsync($"DELETE SocioSecundador WHERE SolicitudId = {solicitud.Id}");
            foreach (var rec in solicitud.SociosSecundadores)
            {
                var embarcacionEntry = entry.Collection(s => s.SociosSecundadores).FindEntry(rec);
                if (embarcacionEntry != null)
                {
                    embarcacionEntry.State = EntityState.Added;
                }
            }
            // -- Memebresias
            await _db.Database.ExecuteSqlRawAsync($"DELETE MembresiaAlterna WHERE SolicitudId = {solicitud.Id}");
            foreach (var rec in solicitud.MembresiasAlternas)
            {
                var embarcacionEntry = entry.Collection(s => s.MembresiasAlternas).FindEntry(rec);
                if (embarcacionEntry != null)
                {
                    embarcacionEntry.State = EntityState.Added;
                }
            }
            await _db.SaveChangesAsync();
            // -- Dependientes
            await _db.Database.ExecuteSqlRawAsync($"DELETE Dependiente WHERE SolicitudId = {solicitud.Id}");
            foreach (var rec in solicitud.Dependientes)
            {
                _db.Add(rec);
            }
            await _db.SaveChangesAsync();
            // -- Referencias
            await _db.Database.ExecuteSqlRawAsync($"DELETE ReferenciaBancaria WHERE SolicitudId = {solicitud.Id}");
            foreach (var rec in solicitud.ReferenciasBancarias)
            {
                _db.Add(rec);
            }
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpPost("submit", Name = "SometerSolicitud")]
    public async Task<IActionResult> PostReject([FromBody] SometerSolicitudEvent someterEvent)
    {
        var solicitud = await _db.FindAsync<Solicitud>(someterEvent.SolicitudId);
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
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("postpone", Name = "PostponerSolicitud")]
    public async Task<IActionResult> PostPostone([FromBody] PostponerSolicitudEvent postponerEvent)
    {
        var solicitud = await _db.FindAsync<Solicitud>(postponerEvent.SolicitudId);
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
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("reject", Name = "RechazarSolicitud")]
    public async Task<IActionResult> PostReject([FromBody] RechazarSolicitudEvent rechazarEvent)
    {
        
        var solicitud = await _db.FindAsync<Solicitud>(rechazarEvent.SolicitudId);
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
        
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("approve", Name = "AprobarSolicitud")]
    public async Task<IActionResult> PostApproval([FromBody] AprobarSolicitudEvent aprobarEvent, [FromServices] ICarnetService carnetService)
    {
        
        var solicitud = await _db.FindAsync<Solicitud>(aprobarEvent.SolicitudId);
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
        _db.Add(socio);
        await _db.SaveChangesAsync();
        //
        //
        await carnetService.CreateInitialCarnets(_db, socio);
        //
        await _db.SaveChangesAsync();
        return Ok();
    }
}