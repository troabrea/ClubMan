using System.Text;
using ClubMan.Shared.Dto;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class SmsController : TenantController
{
    private readonly ILogger<SmsController> _logger;
    private readonly IHttpClientFactory _clientFactory;
    private readonly AppSettings _appSettings;
    
    public SmsController(IConfiguration configuration, ILogger<SmsController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _appSettings = configuration.GetSection(AppSettings.ConfigKey).Get<AppSettings>();    
    }
    [HttpPost("SolicitarLoginPin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SolicitarLoginPin(SmsDto smsDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        //
        var req = new SmsRequestDto()
        {
            ClientKey = _appSettings.SmsApiKey,
            ClientId = _appSettings.SmsPlataform,
            Celular = smsDto.Celular,
            Mensaje = smsDto.Mensaje,
            Referencia = "LoginPin_" + Guid.NewGuid().ToString(),
        };
        var httpClient = _clientFactory.CreateClient();
        httpClient.BaseAddress = new Uri( _appSettings.SmsApiUrl );
        var json = System.Text.Json.JsonSerializer.Serialize(req);
        _logger.LogInformation(json);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(
            "SmsInternal", data);

        response.EnsureSuccessStatusCode();
        
        return Ok();
    }
}

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class AppEventsController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<AppEventsController> _logger;

    public AppEventsController(ClubManContext db, ILogger<AppEventsController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }
    
    #region Invitados
    
    [HttpPost("SolicitarInvitacion", Name = "SolicitarInvitacion")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [Produces(typeof(InvitacionDeSocio))]
    public async Task<ActionResult<InvitacionDeSocio>> AddInvitationRequest([FromBody] SolicitarInvitadoEvent solicitudInvitado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        //
        var carnet = await _db.Carnets.FindAsync(solicitudInvitado.CarnetId);
        if (carnet == null)
        {
            return NotFound();
        }

        if (carnet.Estatus != EstatusCarnet.Activo)
        {
            return Unauthorized();
        }
        var socio = await _db.Socios.FindAsync(carnet.SocioId);
        if (socio == null)
        {
            return NotFound();
        }

        if (socio.EstatusMembresia == EstatusMembresia.Bloqueada ||
            socio.EstatusMembresia == EstatusMembresia.Cancelada)
        {
            return Unauthorized();
        }
        //
        var policy = await _db.Politicas.FirstOrDefaultAsync();
        if (policy != null)
        {
            
            // Invitados mismo día
            if (policy.InvitadosPorDia > 0)
            {
                var fechaHoraInicio = solicitudInvitado.FechaHora.Date;
                var fechaHoraFin = solicitudInvitado.FechaHora.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                var invitadosTotal = await _db.InvitacionesDeSocio.CountAsync(x =>
                    x.SocioId == carnet.SocioId && x.FechaHoraVisita >= fechaHoraInicio &&
                    x.FechaHoraVisita <= fechaHoraFin);
                if (invitadosTotal >= policy.InvitadosPorDia)
                {
                    return Conflict();
                }
            }
            
            // Visitas inivitado
            if(policy.VisitasAlMesInvitados > 0) 
            {
                var visitasInvitado = await _db.VisitasInvitado.FirstOrDefaultAsync(x =>
                    x.NumeroIdentidad == solicitudInvitado.NumeroIdentidad && x.Ano == solicitudInvitado.FechaHora.Year &&
                    x.Mes == solicitudInvitado.FechaHora.Month);
                
                if (visitasInvitado != null && visitasInvitado.Cantidad >= policy.VisitasAlMesInvitados)
                {
                    return Forbid();
                }
            }
            
        }
        //
        var invitacion = new InvitacionDeSocio()
        {
            Id = Guid.NewGuid(),
            SolicitudId = solicitudInvitado.SolicitudId,
            SocioId = socio.Id,
            FechaHora = DateTime.Now,
            NumeroIdentidad = solicitudInvitado.NumeroIdentidad,
            Estatus = EstatusInvitacion.Sometida,
            Email = solicitudInvitado.Email,
            WhatsApp = solicitudInvitado.WhatsApp,
            NombreCompleto = solicitudInvitado.Nombre,
            NumeroCarnet = solicitudInvitado.CarnetId,
            FechaHoraVisita = solicitudInvitado.FechaHora
        };
        _db.Add(invitacion);
        //
        await _db.SaveChangesAsync();
        return Created($"invitaciones/{invitacion.Id.ToString()}", invitacion);
    }
    
    [HttpDelete("RemoverInvitacion/{invitacionId:Guid}", Name = "RemoverInvitacion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(typeof(InvitacionDeSocio))]
    public async Task<ActionResult<InvitacionDeSocio>> RemoveInvitationRequest(Guid invitacionId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        //
        var invitacion = await _db.InvitacionesDeSocio.FindAsync(invitacionId);
        if (invitacion == null)
        {
            return NotFound();
        }
        //
        if (invitacion.Estatus != EstatusInvitacion.Sometida)
        {
            return BadRequest();
        }
        _db.Remove(invitacion);
        //
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    #endregion
    
    #region Eventos

    

    #endregion
    
}