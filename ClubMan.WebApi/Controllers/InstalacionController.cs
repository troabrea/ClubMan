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
public class InstalacionController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<InstalacionController> _logger;

    public InstalacionController(ClubManContext db, ILogger<InstalacionController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetInstalaciones")]
    public async Task<IEnumerable<InstalacionViewModel>> Get()
    {
        return await _db.Instalaciones.Where(x => x.Activo).Join(_db.Localidades, i => i.LocalidadId, l => l.Id, (i, l) =>
            new InstalacionViewModel()
            {
                Id = i.Id,
                Instalacion = i,
                Localidad = l
            }).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllInstalaciones")]
    public async Task<IEnumerable<InstalacionViewModel>> GetAll()
    {
        return await _db.Instalaciones.Join(_db.Localidades, i => i.LocalidadId, l => l.Id, (i, l) =>
            new InstalacionViewModel()
            {
                Id = i.Id,
                Instalacion = i,
                Localidad = l
            }).ToListAsync();
    }
    
    [HttpPost(Name = "AddInstalacion")]
    public async Task<IActionResult> Post([FromBody] Instalacion instalacion)
    {
        _db.Add(instalacion);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateInstalacion")]
    public async Task<IActionResult> Put([FromBody] Instalacion instalacion)
    {
        var entry = _db.Entry(instalacion);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpDelete("{instalacionId:guid}", Name = "RemoveInstalacion")]
    public async Task<IActionResult> Delete(Guid instalacionId)
    {
        var instalacion = _db.Find<Instalacion>(instalacionId);
        if (instalacion != null)
        {
            _db.Remove(instalacion);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}