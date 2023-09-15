using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class EventoController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<EventoController> _logger;

    public EventoController(ClubManContext db, ILogger<EventoController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }
    [HttpGet(Name = "GetEventos")]
    public async Task<IEnumerable<EventoViewModel>> Get()
    {
        return await _db.EventosDeSocio
            .Join(_db.Socios, e => e.SocioId, s => s.Id, (e, s) => new {Evento = e, Socio = s})
            .Join(_db.Instalaciones, x => x.Evento.InstalacionId, i => i.Id,
                (x, i) => new {Evento = x.Evento, Socio = x.Socio, Instalacion = i})
            .Join(_db.Localidades, x => x.Instalacion.LocalidadId, l => l.Id, (x, l) => new EventoViewModel()
            {
                Id=x.Evento.Id,
                Evento = x.Evento,
                Instalacion = x.Instalacion,
                Localidad = l,
                Socio = x.Socio
            }).ToListAsync();
    }
    [HttpGet("{socioId}", Name = "GetEventosSocio")]
    public async Task<IEnumerable<EventoViewModel>> GetSocio(long socioId)
    {
        return await _db.EventosDeSocio.Where(x => x.SocioId == socioId && x.FechaHora >= DateTime.Today)
            .Join(_db.Socios, e => e.SocioId, s => s.Id, (e, s) => new {Evento = e, Socio = s})
            .Join(_db.Instalaciones, x => x.Evento.InstalacionId, i => i.Id,
                (x, i) => new {Evento = x.Evento, Socio = x.Socio, Instalacion = i})
            .Join(_db.Localidades, x => x.Instalacion.LocalidadId, l => l.Id, (x, l) => new EventoViewModel()
            {
                Id=x.Evento.Id,
                Evento = x.Evento,
                Instalacion = x.Instalacion,
                Localidad = l,
                Socio = x.Socio
            }).ToListAsync();
    }
    
    [HttpGet("hoy", Name = "GetEventosHoy")]
    public async Task<IEnumerable<EventoViewModel>> GetEventosDeHoy()
    {
        return await _db.EventosDeSocio.Where(x => x.FechaHora >= DateTime.Today && x.FechaHora < DateTime.Today.AddDays(1))
            .Join(_db.Socios, e => e.SocioId, s => s.Id, (e, s) => new {Evento = e, Socio = s})
            .Join(_db.Instalaciones, x => x.Evento.InstalacionId, i => i.Id,
                (x, i) => new {Evento = x.Evento, Socio = x.Socio, Instalacion = i})
            .Join(_db.Localidades, x => x.Instalacion.LocalidadId, l => l.Id, (x, l) => new EventoViewModel()
            {
                Id=x.Evento.Id,
                Evento = x.Evento,
                Instalacion = x.Instalacion,
                Localidad = l,
                Socio = x.Socio
            }).ToListAsync();
    }
    
    [HttpGet("byId/{eventoId}", Name = "GetEventoById")]
    public async Task<EventoViewModel> GetById(long eventoId)
    {
        return await _db.EventosDeSocio.Where(x => x.Id == eventoId && x.FechaHora >= DateTime.Today)
            .Join(_db.Socios, e => e.SocioId, s => s.Id, (e, s) => new {Evento = e, Socio = s})
            .Join(_db.Instalaciones, x => x.Evento.InstalacionId, i => i.Id,
                (x, i) => new {Evento = x.Evento, Socio = x.Socio, Instalacion = i})
            .Join(_db.Localidades, x => x.Instalacion.LocalidadId, l => l.Id, (x, l) => new EventoViewModel()
            {
                Id=x.Evento.Id,
                Evento = x.Evento,
                Instalacion = x.Instalacion,
                Localidad = l,
                Socio = x.Socio
            }).FirstOrDefaultAsync();
    }
    
    [HttpGet("byMovimientoId/{movimientoId:guid}", Name = "GetEventoByMovimientoId")]
    public async Task<EventoViewModel> GetById(Guid movimientoId)
    {
        return await _db.EventosDeSocio.Where(x => x.MovimientoId == movimientoId && x.FechaHora >= DateTime.Today)
            .Join(_db.Socios, e => e.SocioId, s => s.Id, (e, s) => new {Evento = e, Socio = s})
            .Join(_db.Instalaciones, x => x.Evento.InstalacionId, i => i.Id,
                (x, i) => new {Evento = x.Evento, Socio = x.Socio, Instalacion = i})
            .Join(_db.Localidades, x => x.Instalacion.LocalidadId, l => l.Id, (x, l) => new EventoViewModel()
            {
                Id=x.Evento.Id,
                Evento = x.Evento,
                Instalacion = x.Instalacion,
                Localidad = l,
                Socio = x.Socio
            }).FirstOrDefaultAsync();
    }
    
    
    
    [HttpPost(Name = "AddEvento")]
    public async Task<IActionResult> Post([FromBody] EventoDeSocio evento)
    {
        var instalacion = await _db.Instalaciones.FirstOrDefaultAsync(x => x.Id == evento.InstalacionId);
        if (instalacion != null)
        {
            evento.Costo = instalacion.CostoReserva;
        }
        _db.Add(evento);
        await _db.SaveChangesAsync();
        //
        return Ok();
    }
    
    [HttpPut(Name = "UpdateEvento")]
    public async Task<IActionResult> Put([FromBody] EventoDeSocio evento)
    {
        var entry = _db.Entry(evento);
        if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }

    
    [HttpDelete("{eventoId:long}", Name = "RemoveEvento")]
    public async Task<IActionResult> Delete(long eventoId)
    {
        var evento = _db.Find<EventoDeSocio>(eventoId);
        if (evento != null)
        {
            _db.Remove(evento);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpPost("submit", Name = "SometerEvento")]
    public async Task<IActionResult> PostSubmit([FromBody] SometerEventoEvent someterEvent)
    {
        var evento = await _db.FindAsync<EventoDeSocio>(someterEvent.EventoId);
        var socio = await _db.FindAsync<Socio>(evento.SocioId);
        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = evento.SocioId,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.SolicitarActividad,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = someterEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea realizar un evento: {evento.Descripcion}, para {evento.Personas} persona(s) el {evento.FechaHora.ToString("dd-MMM-yyyy hh:mm")}."
        };
        _db.Add(mov);
        //
        evento.MovimientoId = refId;
        evento.Estatus = EstatusEvento.Sometido;
        await _db.SaveChangesAsync();
        return Ok();
    }
}