using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class EventoController : TenantController
{
    private readonly ILogger<EventoController> _logger;

    public EventoController(ILogger<EventoController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet("{socioId}", Name = "GetEventos")]
    public async Task<IEnumerable<EventoViewModel>> Get(long socioId)
    {
        using var session = _store.OpenSession(TenantId);
        Socio socio = null;
        var batch = session.CreateBatchQuery();
        var localidades = batch.Query<Localidad>().ToList();
        var instalaciones = batch.Query<Instalacion>().ToList();
        var eventos = batch.Query<EventoDeSocio>()
            .Include<Socio>(x => x.SocioId, x=> socio = x)
            .Where(x => x.SocioId == socioId )
            .ToList();

        await batch.Execute();
        
        return eventos.Result.Select(x => new EventoViewModel()
        {
            Id = x.Id,
            Evento = x,
            Instalacion = instalaciones.Result.First(r => r.Id == x.InstalacionId),
            Localidad = localidades.Result.First(l => l.Id == instalaciones.Result.First(r => r.Id == x.InstalacionId).LocalidadId ),
            Socio = socio
        });
    }
    
    [HttpPost(Name = "AddOrUpdateEvento")]
    public async Task<IActionResult> Post([FromBody] EventoDeSocio evento)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(evento);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{eventoId:long}", Name = "RemoveEvento")]
    public async Task<IActionResult> Delete(long eventoId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<EventoDeSocio>(eventoId);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("submit", Name = "SometerEvento")]
    public async Task<IActionResult> PostSubmit([FromBody] SometerEventoEvent someterEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var evento = await session.LoadAsync<EventoDeSocio>(someterEvent.EventoId);
        var socio = await session.LoadAsync<Socio>(evento.SocioId);
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
        //
        evento.MovimientoId = refId;
        evento.Estatus = EstatusEvento.Sometido;
        session.Store(evento);
        session.Store(mov);
        await session.SaveChangesAsync();
        return Ok();
    }
}