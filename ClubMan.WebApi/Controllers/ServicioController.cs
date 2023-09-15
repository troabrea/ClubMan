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
public class ServicioController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<ServicioController> _logger;

    public ServicioController(ClubManContext db, ILogger<ServicioController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetServicios")]
    public async Task<IReadOnlyList<Servicio>> Get()
    {
        return await _db.Servicios.Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllServicios")]
    public async Task<IReadOnlyList<Servicio>> GetAll()
    {
        return await _db.Servicios.ToListAsync();
    }
    
    [HttpPost(Name = "AddServicio")]
    public async Task<IActionResult> Post([FromBody] Servicio servicio)
    {
        _db.Add(servicio);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPut(Name = "UpdateServicio")]
    public async Task<IActionResult> Put([FromBody] Servicio servicio)
    {
        var entry = _db.Entry(servicio);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    [HttpDelete("{servicioId:guid}", Name = "RemoveServicio")]
    public async Task<IActionResult> Delete(Guid servicioId)
    {
        var servicio = _db.Find<Servicio>(servicioId);
        if (servicio != null)
        {
            _db.Remove(servicio);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}