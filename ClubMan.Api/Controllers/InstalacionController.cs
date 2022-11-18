using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class InstalacionController : TenantController
{
    private readonly ILogger<InstalacionController> _logger;

    public InstalacionController(ILogger<InstalacionController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetInstalaciones")]
    public async Task<IEnumerable<InstalacionViewModel>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        var localidades = new Dictionary<Guid, Localidad>();
        var instalaciones = await session.Query<Instalacion>()
            .Where(x => x.Activo)
            .Include(x => x.LocalidadId, localidades)
            .ToListAsync();

        return instalaciones.Select(x => new InstalacionViewModel()
        {
            Id = x.Id,
            Instalacion = x,
            Localidad = localidades[x.LocalidadId]
        });
        
        //return await Session.Query<Instalacion>().Where(x => x.Activo == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllInstalaciones")]
    public async Task<IEnumerable<InstalacionViewModel>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        var localidades = new Dictionary<Guid, Localidad>();
        var instalaciones = await session.Query<Instalacion>()
            .Include(x => x.LocalidadId, localidades)
            .ToListAsync();

        return instalaciones.Select(x => new InstalacionViewModel()
        {
            Id = x.Id,
            Instalacion = x,
            Localidad = localidades[x.LocalidadId]
        });

        // return await Session.Query<Instalacion>().ToListAsync();
    }
    
    [HttpPost(Name = "AddOrUpdateInstalacion")]
    public async Task<IActionResult> Post([FromBody] Instalacion instalacion)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(instalacion);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{instalacionId:guid}", Name = "RemoveInstalacion")]
    public async Task<IActionResult> Delete(Guid instalacionId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Instalacion>(instalacionId);
        await session.SaveChangesAsync();
        return Ok();
    }
}