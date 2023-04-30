using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class ActividadController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<ActividadController> _logger;

    public ActividadController(ClubManContext db, ILogger<ActividadController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetActividades")]
    public async Task<IEnumerable<ActividadViewModel>> Get()
    {
        return await _db.Actividades.Where(x => x.FechaHora >= DateTime.Today)
            .Join(_db.Instalaciones, a => a.InstalacionId, i => i.Id, (a, i) => new {Actividad = a, Instalacion = i})
            .Join(_db.Localidades, (obj) => obj.Instalacion.LocalidadId, l => l.Id,(obj, l) => new ActividadViewModel()
            {
                Id = obj.Actividad.Id,
                Actividad = obj.Actividad,
                Instalacion = obj.Instalacion,
                Localidad = l
            }).ToListAsync();
    }
    
    [HttpGet("hoy",Name = "GetActividadesDeHoy")]
    public async Task<IEnumerable<ActividadViewModel>> GetToday()
    {
        return await _db.Actividades.Where(x => x.FechaHora >= DateTime.Today && x.FechaHora < DateTime.Today.AddDays(1))
            .Join(_db.Instalaciones, a => a.InstalacionId, i => i.Id, (a, i) => new {Actividad = a, Instalacion = i})
            .Join(_db.Localidades, (obj) => obj.Instalacion.LocalidadId, l => l.Id,(obj, l) => new ActividadViewModel()
            {
                Id = obj.Actividad.Id,
                Actividad = obj.Actividad,
                Instalacion = obj.Instalacion,
                Localidad = l
            }).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllActividades")]
    public async Task<IEnumerable<ActividadViewModel>> GetAll()
    {
        return await _db.Actividades
            .Join(_db.Instalaciones, a => a.InstalacionId, i => i.Id, (a, i) => new {Actividad = a, Instalacion = i})
            .Join(_db.Localidades, (obj) => obj.Instalacion.LocalidadId, l => l.Id,(obj, l) => new ActividadViewModel()
            {
                Id = obj.Actividad.Id,
                Actividad = obj.Actividad,
                Instalacion = obj.Instalacion,
                Localidad = l
            }).ToListAsync();
    }
    
    [HttpPost(Name = "AddActividad")]
    public async Task<IActionResult> Post([FromBody] Actividad actividad)
    {
        _db.Add(actividad);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateActividad")]
    public async Task<IActionResult> Put([FromBody] Actividad actividad)
    {
        var entry = _db.Entry(actividad);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpDelete("{actividadId:guid}", Name = "RemoveActividad")]
    public async Task<IActionResult> Delete(Guid actividadId)
    {
        var actividad = _db.Find<Actividad>(actividadId);
        if (actividad != null)
        {
            _db.Remove(actividad);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}