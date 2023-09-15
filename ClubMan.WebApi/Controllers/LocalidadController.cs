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
public class LocalidadController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<LocalidadController> _logger;

    public LocalidadController(ClubManContext db, ILogger<LocalidadController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetLocalidades")]
    public async Task<IReadOnlyList<Localidad>> Get()
    {
        return await _db.Localidades.Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllLocalidades")]
    public async Task<IReadOnlyList<Localidad>> GetAll()
    {
        return await _db.Localidades.AsNoTracking().ToListAsync();
    }
    
    [HttpPost(Name = "AddLocalidad")]
    public async Task<IActionResult> Post([FromBody] Localidad localidad)
    {
        _db.Add(localidad);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateLocalidad")]
    public async Task<IActionResult> Put([FromBody] Localidad localidad)
    {
        var entry = _db.Entry(localidad);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpDelete("{localidadId:guid}", Name = "RemoveLocalidad")]
    public async Task<IActionResult> Delete(Guid localidadId)
    {
        var localidad = _db.Find<Localidad>(localidadId);
        if (localidad != null)
        {
            _db.Remove(localidad);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}