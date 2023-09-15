using System.Net;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class AppEventsController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<AppEventsController> _logger;

    public AppEventsController(IHttpClientFactory factory, ILogger<AppEventsController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
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

        var result = await _http.PostAsJsonAsync("api/AppEvents/SolicitarInvitacion", solicitudInvitado);
        //
        if (result.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }

        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            return Unauthorized();
        }
        if (result.StatusCode == HttpStatusCode.Conflict)
        {
            return Conflict();
        }
        if (result.StatusCode == HttpStatusCode.Forbidden)
        {
            return Forbid();
        }
        var invitacion = await result.Content.ReadFromJsonAsync<InvitacionDeSocio>();
        //
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

        var result = await _http.DeleteAsync($"api/AppEvents/RemoverInvitacion/{invitacionId}");
        if(result.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
        if(result.StatusCode == HttpStatusCode.BadRequest)
        {
            return BadRequest();
        }
        return Ok();
    }
    
    #endregion
    
}