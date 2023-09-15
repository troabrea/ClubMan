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
public class CarnetController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<CarnetController> _logger;

    public CarnetController(ClubManContext db, ILogger<CarnetController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet("{carnetId}", Name = "GetCarnetById")]
    [Produces(typeof(Carnet))]
    public async Task<IActionResult> GetById(string carnetId)
    {
        var carnet = await _db.Carnets.FirstOrDefaultAsync(x => x.CarnetId == carnetId);
        if (carnet == null)
        {
            return NotFound();
        }

        return Ok(carnet);
    }
    
    [HttpGet("Socio/{socioId:long}", Name = "GetSocioCarnets")]
    [Produces(typeof(IEnumerable<Carnet>))]
    public async Task<IActionResult> GetSocioCarnets(long socioId)
    {
        return Ok(await _db.Carnets.Where(x => x.SocioId == socioId).ToListAsync());
    }
}