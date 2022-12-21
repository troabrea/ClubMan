using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class VisitasController : TenantController
{
    private readonly ILogger<VisitasController> _logger;

    public VisitasController(ILogger<VisitasController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpPost("socio/{porteroId:Guid}", Name = "PostVisitaSocio")]
    public async Task<IActionResult> PostVisitaSocio(Carnet carnet, Guid porteroId)
    {
        using var session = _store.OpenSession(TenantId);

        var periodoId = DateTime.Today.ToString("yyyy_MM");

        var visitaId = $"{carnet.SocioId}_{periodoId}";
        
        var visitaCarnetEvent = new VisitaCarnetRegistradaEvent()
        {
            Id = visitaId,
            CarnetId = carnet.CarnetId,
            TipoCarnet = carnet.Tipo,
            FechaHora = DateTime.Now,
            PorteroId = porteroId,
            SocioId = carnet.SocioId,
        };
        
        var visitaSocioEvent = new VisitaSocioRegistradaEvent()
        {
            Id = periodoId,
            TipoCarnet = carnet.Tipo,
            FechaHora = DateTime.Now
        };
        
        session.Events.AggregateStream<VisitasSocio>(visitaId);
        session.Events.Append(visitaId, visitaCarnetEvent);
        
        session.Events.AggregateStream<Visitas>(periodoId);
        session.Events.Append(periodoId, visitaSocioEvent);
        
        await session.SaveChangesAsync();
        
        return Ok();
    }
    [HttpPost("socio/adicional/{porteroId:Guid}", Name = "PostVisitaAdicionalSocio")]
    public async Task<IActionResult> PostVisitaAdicionalSocio(VisitaAdicionalSocioRegistradaEvent visitaEvent, Guid porteroId)
    {
        using var session = _store.OpenSession(TenantId);

        var periodoId = DateTime.Today.ToString("yyyy_MM");

        var visitaId = $"{visitaEvent.SocioId}_{periodoId}";
        visitaEvent.Id = visitaId;
        
        var visitaSocioEvent = new VisitaSocioRegistradaEvent()
        {
            Id = periodoId,
            TipoCarnet = TipoCarnet.Adicional,
            FechaHora = DateTime.Now
        };
        
        session.Events.AggregateStream<VisitasSocio>(visitaId);
        session.Events.Append(visitaId, visitaEvent);
        
        session.Events.AggregateStream<Visitas>(periodoId);
        session.Events.Append(periodoId, visitaSocioEvent);
        
        await session.SaveChangesAsync();
        
        return Ok();
    }
    [HttpPost("socio/invitacion/{invitacionId:Guid}/{porteroId:Guid}", Name = "PostVisitaInvitadoSocio")]
    public async Task<IActionResult> PostVisitaInvitadoSocio(Guid invitacionId, Guid porteroId)
    {
        using var session = _store.OpenSession(TenantId);
        
        var invitacion = await session.LoadAsync<InvitacionDeSocio>(invitacionId);
        if (invitacion == null)
        {
            return NotFound();
        }
        if (invitacion.Estatus != EstatusInvitacion.Sometida)
        {
            return BadRequest("Invitación inválida");
        }
        var socio = await session.LoadAsync<Socio>(invitacion.SocioId);
        
        if (socio == null)
        {
            return BadRequest("Socio no encontrado");
        }
        
        if (socio.EstatusMembresia == EstatusMembresia.Bloqueada || socio.EstatusMembresia == EstatusMembresia.Cancelada)
        {
            return Unauthorized();
        }
        
        var periodoId = DateTime.Today.ToString("yyyy_MM");
        
        var visitaId = $"{invitacion.NumeroIdentidad}_{periodoId}";
        
        var visitaSocioId = $"{invitacion.SocioId}_{periodoId}";
        
        var visitaEvent = new VisitaInvitadoRegistradaEvent()
        {
            Id = visitaId,
            FechaHora = DateTime.Now,
            NumeroIdentidad = invitacion.NumeroIdentidad,
            InvitadoDe = socio.Nombre,
            SocioId = socio.Id,
            CarnetId = string.IsNullOrEmpty(invitacion.NumeroCarnet) ? socio.NumeroCarnet : invitacion.NumeroCarnet
        };
        var visitaInvitadoDeSocioEvent = new VisitaInvitadoSocioRegistradaEvent()
        {
            Id = visitaSocioId,
            FechaHora = DateTime.Now,
            CarnetId = socio.NumeroCarnet,
            SocioId = invitacion.SocioId
        };
        var visitaSocioEvent = new VisitaSocioRegistradaEvent()
        {
            Id = periodoId,
            TipoCarnet = TipoCarnet.Adicional,
            FechaHora = DateTime.Now
        };
        
        // Entrada del Invitado
        session.Events.AggregateStream<VisitasInvitado>(visitaId);
        session.Events.Append(visitaId, visitaEvent);
        
        // Acumular en el Socio
        session.Events.AggregateStream<VisitasSocio>(visitaSocioId);
        session.Events.Append(visitaSocioId, visitaInvitadoDeSocioEvent);
        
        // Acumular en Club
        session.Events.AggregateStream<Visitas>(periodoId);
        session.Events.Append(periodoId, visitaSocioEvent);

        invitacion.Estatus = EstatusInvitacion.Utilizada;
        invitacion.FechaHoraVisita = DateTime.Now;
        session.Store(invitacion);
        
        await session.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet(Name = "GetResumenVisitas")]
    public async Task<IReadOnlyList<Visitas>> GetVisitas()
    {
        using var session = _store.OpenSession(TenantId);
        var visitas =await  session.Query<Visitas>()
            .OrderByDescending(x => x.Ano)
            .ThenByDescending(x => x.Mes)
            .Take(3)
            .ToListAsync();
        return visitas;
    }
    
    [HttpGet("socio/{socioId:long}", Name = "GetVisitasSocioActual")]
    public  async Task<VisitasSocio> GetVisitasSocioActual(long socioId)
    {
        var periodoId = DateTime.Today.ToString("yyyy_MM");
        var visitaId = $"{socioId}_{periodoId}";
        
        using var session = _store.OpenSession(TenantId);
        var result = await session.LoadAsync<VisitasSocio>(visitaId);
        if (result == null)
        {
            result = new()
            {
                Ano = DateTime.Today.Year,
                Mes = DateTime.Today.Month,
                Id = visitaId,
                SocioId = socioId
            };
        }
        return result;
    }

}