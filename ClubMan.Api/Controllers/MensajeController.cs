using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class MensajeController : TenantController
{
    private readonly ILogger<MensajeController> _logger;

    public MensajeController(ILogger<MensajeController> logger, IDocumentStore store, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMensajes")]
    public async Task<IReadOnlyList<Mensaje>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Mensaje>().Where(x => x.Enviado == false).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllMensajes")]
    public async Task<IReadOnlyList<Mensaje>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Mensaje>().ToListAsync();
    }
    
    [HttpPost(Name = "AddOrUpdateMensaje")]
    public async Task<IActionResult> Post([FromBody] Mensaje mensaje)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(mensaje);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{mensajeId:guid}", Name = "RemoveMensaje")]
    public async Task<IActionResult> Delete(Guid mensajeId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Mensaje>(mensajeId);
        await session.SaveChangesAsync();
        return Ok();
    }
}