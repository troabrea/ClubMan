using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class ServicioController : TenantController
{
    private readonly ILogger<ServicioController> _logger;

    public ServicioController(ILogger<ServicioController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetServicios")]
    public async Task<IReadOnlyList<Servicio>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Servicio>().Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllServicios")]
    public async Task<IReadOnlyList<Servicio>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Servicio>().ToListAsync();
    }
    
    [HttpPost(Name = "AddOrUpdateServicio")]
    public async Task<IActionResult> Post([FromBody] Servicio servicio)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(servicio);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{servicioId:guid}", Name = "RemoveServicio")]
    public async Task<IActionResult> Delete(Guid servicioId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Servicio>(servicioId);
        await session.SaveChangesAsync();
        return Ok();
    }
}