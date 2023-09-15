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
public class CortesiaController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<CortesiaController> _logger;

    public CortesiaController(ClubManContext db, ILogger<CortesiaController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetCortesias")]
    public async Task<IReadOnlyList<Cortesia>> Get()
    {
        return await _db.Cortesias.Where(x => x.FechaExpiracion >= DateTime.Today).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllCortesias")]
    public async Task<IReadOnlyList<Cortesia>> GetAll()
    {
        return await _db.Cortesias.ToListAsync();
    }
    
    [HttpGet("byId/{numeroIdentidad}", Name = "GetCortesiaById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(typeof(Cortesia))]
    public async Task<IActionResult> GetById(string numeroIdentidad)
    {
        var result = await _db.Cortesias.SingleOrDefaultAsync(x => x.NumeroIdentidad == numeroIdentidad);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    
    [HttpPost(Name = "AddCortesia")]
    public async Task<IActionResult> Post([FromBody] Cortesia cortesia)
    {
        _db.Add(cortesia);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPut(Name = "UpdateCortesia")]
    public async Task<IActionResult> Put([FromBody] Cortesia cortesia)
    {
        var entry = _db.Entry(cortesia);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    [HttpDelete("{servicioId:guid}", Name = "RemoveCortesia")]
    public async Task<IActionResult> Delete(long cortesiaId)
    {
        var servicio = _db.Find<Servicio>(cortesiaId);
        if (servicio != null)
        {
            _db.Remove(servicio);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}