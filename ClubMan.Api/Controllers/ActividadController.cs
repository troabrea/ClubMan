using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class ActividadController : TenantController
{
    private readonly ILogger<ActividadController> _logger;

    public ActividadController(ILogger<ActividadController> logger, IHttpContextAccessor httpContextAccessor, IDocumentStore store) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetActividades")]
    public async Task<IEnumerable<ActividadViewModel>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        var batch = session.CreateBatchQuery();
        var localidades = batch.Query<Localidad>().ToList();
        var instalaciones = batch.Query<Instalacion>().ToList();
        var actividades = batch.Query<Actividad>()
            .Where(x => x.FechaHora >= DateTime.Today)
            .ToList();

        await batch.Execute();
        
        return actividades.Result.Select(x => new ActividadViewModel()
        {
            Id = x.Id,
            Actividad = x,
            Instalacion = instalaciones.Result.First(r => r.Id == x.InstalacionId),
            Localidad = localidades.Result.First(l => l.Id == instalaciones.Result.First(r => r.Id == x.InstalacionId).LocalidadId )
        });
    }
    
    [HttpGet("all", Name = "GetAllActividades")]
    public async Task<IEnumerable<ActividadViewModel>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        var batch = session.CreateBatchQuery();
        var localidades = batch.Query<Localidad>().ToList();
        var instalaciones = batch.Query<Instalacion>().ToList();
        var actividades = batch.Query<Actividad>()
            .ToList();

        await batch.Execute();
        
        return actividades.Result.Select(x => new ActividadViewModel()
        {
            Id = x.Id,
            Actividad = x,
            Instalacion = instalaciones.Result.First(r => r.Id == x.InstalacionId),
            Localidad = localidades.Result.First(l => l.Id == instalaciones.Result.First(r => r.Id == x.InstalacionId).LocalidadId )
        });
    }
    
    [HttpPost(Name = "AddOrUpdateActividad")]
    public async Task<IActionResult> Post([FromBody] Actividad actividad)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(actividad);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{actividadId:guid}", Name = "RemoveActividad")]
    public async Task<IActionResult> Delete(Guid actividadId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Actividad>(actividadId);
        await session.SaveChangesAsync();
        return Ok();
    }
}