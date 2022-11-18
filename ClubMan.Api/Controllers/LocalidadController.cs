using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class LocalidadController : TenantController
{
    private readonly ILogger<LocalidadController> _logger;

    public LocalidadController(ILogger<LocalidadController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetLocalidades")]
    public async Task<IReadOnlyList<Localidad>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Localidad>().Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllLocalidades")]
    public async Task<IReadOnlyList<Localidad>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Localidad>().ToListAsync();
    }
    
    [HttpPost(Name = "AddOrUpdateLocalidad")]
    public async Task<IActionResult> Post([FromBody] Localidad localidad)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(localidad);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{localidadId:guid}", Name = "RemoveLocalidad")]
    public async Task<IActionResult> Delete(Guid localidadId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Localidad>(localidadId); 
        await session.SaveChangesAsync();
        return Ok();
    }
}