using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class VisitasController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<VisitasController> _logger;

    public VisitasController(ClubManContext db, ILogger<VisitasController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpPost("socio/{porteroId:Guid}", Name = "PostVisitaSocio")]
    public async Task<IActionResult> PostVisitaSocio(Carnet carnet, Guid porteroId)
    {
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

        var visitaSocio = await _db.VisitasSocio.FindAsync(visitaId);
        if (visitaSocio == null)
        {
            visitaSocio = new VisitasSocio()
            {
                Id = visitaId,
            };
            visitaSocio.Apply(visitaCarnetEvent);
            _db.Add(visitaSocio);
        }
        else
        {
            visitaSocio.Apply(visitaCarnetEvent);
        }

        var visita = await _db.Visitas.FindAsync(periodoId);
        if (visita == null)
        {
            visita = new Visitas()
            {
                Id = periodoId
            };
            visita.Apply(visitaSocioEvent);
            _db.Add(visita);
        }
        else
        {
            visita.Apply(visitaSocioEvent);
        }
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }
    [HttpPost("socio/adicional/{porteroId:Guid}", Name = "PostVisitaAdicionalSocio")]
    
    public async Task<IActionResult> PostVisitaAdicionalSocio(VisitaAdicionalSocioRegistradaEvent visitaEvent, Guid porteroId)
    {

        var periodoId = DateTime.Today.ToString("yyyy_MM");

        var visitaId = $"{visitaEvent.SocioId}_{periodoId}";
        visitaEvent.Id = visitaId;
        
        var visitaSocioEvent = new VisitaSocioRegistradaEvent()
        {
            Id = periodoId,
            TipoCarnet = TipoCarnet.Adicional,
            FechaHora = DateTime.Now
        };
        
        var visitaAdicionalEvent = new VisitaAdicionalSocioRegistradaEvent()
        {
            Id = periodoId,
            SocioId = visitaEvent.SocioId,
            FechaHora = DateTime.Now,
            CarnetId = visitaEvent.CarnetId,
            NumeroIndentidad = visitaEvent.NumeroIndentidad
        };
        
        var visitaSocio = await _db.VisitasSocio.FindAsync(visitaId);
        if (visitaSocio == null)
        {
            visitaSocio = new VisitasSocio()
            {
                Id = visitaId,
            };
            visitaSocio.Apply(visitaAdicionalEvent);
            _db.Add(visitaSocio);
        }
        else
        {
            visitaSocio.Apply(visitaAdicionalEvent);
        }
        
        var visita = await _db.Visitas.FindAsync(periodoId);
        if (visita == null)
        {
            visita = new Visitas()
            {
                Id = periodoId
            };
            visita.Apply(visitaSocioEvent);
            _db.Add(visita);
        }
        else
        {
            visita.Apply(visitaSocioEvent);
        }
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPost("socio/invitacion/{invitacionId:Guid}/{porteroId:Guid}", Name = "PostVisitaInvitadoSocio")]
    public async Task<IActionResult> PostVisitaInvitadoSocio(Guid invitacionId, Guid porteroId)
    {
        // using var session = _store.OpenSession(TenantId);
        
        var invitacion = await _db.FindAsync<InvitacionDeSocio>(invitacionId);
        if (invitacion == null)
        {
            return NotFound();
        }
        if (invitacion.Estatus != EstatusInvitacion.Sometida)
        {
            return BadRequest("Invitación inválida");
        }
        var socio = await _db.FindAsync<Socio>(invitacion.SocioId);
        
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
        
        var visitaInvitadoEvent = new VisitaInvitadoRegistradaEvent()
        {
            Id = visitaSocioId,
            FechaHora = DateTime.Now,
            CarnetId = socio.NumeroCarnet,
            SocioId = invitacion.SocioId,
            NumeroIdentidad = invitacion.NumeroIdentidad,
            InvitadoDe = string.Empty
        };

        var visitaInvitadoDeSocioEvent = new VisitaInvitadoSocioRegistradaEvent()
        {
            Id = visitaSocioId,
            FechaHora = DateTime.Now,
            CarnetId = socio.NumeroCarnet,
            SocioId = invitacion.SocioId
        };

        var visitaInvitado = await _db.VisitasInvitado.FindAsync(visitaId);
        if (visitaInvitado == null)
        {
            visitaInvitado = new VisitasInvitado()
            {
                Id = visitaId,
            };
            visitaInvitado.Apply(visitaInvitadoEvent);
            _db.Add(visitaInvitado);
        }
        else
        {
            visitaInvitado.Apply(visitaInvitadoEvent);
        }
        
        var visitaSocio = await _db.VisitasSocio.FindAsync(visitaSocioId);
        if (visitaSocio == null)
        {
            visitaSocio = new VisitasSocio()
            {
                Id = visitaSocioId,
            };
            visitaSocio.Apply(visitaInvitadoDeSocioEvent);
            _db.Add(visitaSocio);
        }
        else
        {
            visitaSocio.Apply(visitaInvitadoDeSocioEvent);
        }
        
        var visita = await _db.Visitas.FindAsync(periodoId);
        if (visita == null)
        {
            visita = new Visitas()
            {
                Id = periodoId
            };
            visita.Apply(visitaInvitadoDeSocioEvent);
            _db.Add(visita);
        }
        else
        {
            visita.Apply(visitaInvitadoDeSocioEvent);
        }

        invitacion.Estatus = EstatusInvitacion.Utilizada;
        invitacion.FechaHoraVisita = DateTime.Now;
        
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet(Name = "GetResumenVisitas")]
    public async Task<IReadOnlyList<Visitas>> GetVisitas()
    {
        var visitas =await  _db.Visitas
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
        
        var result = await _db.FindAsync<VisitasSocio>(visitaId);
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


    [HttpPost("manual")]
    [Produces(typeof(VisitaManual))]
    public async Task<IActionResult> PostVisitaManual(VisitaManual visitaManual)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (String.IsNullOrEmpty(visitaManual.Id))
        {
            visitaManual.Id = Guid.NewGuid().ToString();
        }
        _db.VisitasManuales.Add(visitaManual);
        await _db.SaveChangesAsync();
        return Ok(visitaManual);
    }
    
}