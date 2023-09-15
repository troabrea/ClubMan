using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using ClubMan.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class MovimientosController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<MovimientosController> _logger;
    private readonly ICarnetService _carnetService;

    public MovimientosController(ClubManContext db, ILogger<MovimientosController> logger, ICarnetService carnetService,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
        _carnetService = carnetService;
    }
    [HttpGet(Name = "GetMovimientos")]
    public async Task<IReadOnlyList<MovimientoSocio>> Get()
    {
        return await _db.MovimientosSocio.Where(x => x.Estatus == EstatusMovimiento.Pendiente).ToListAsync();
    }
    
    [HttpGet("socio/{socioId:long}", Name = "GetMovimientosSocio")]
    public async Task<IReadOnlyList<MovimientoSocio>> GetBySocio(long socioId)
    {
        return await _db.MovimientosSocio.Where(x => x.SocioId == socioId).ToListAsync();
    }

    [HttpPost("procesar", Name = "ProcesarMovimiento")]
    public async Task<IActionResult> ProcesaMovimiento([FromBody] ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        var movimiento = await _db.FindAsync<MovimientoSocio>(procesaMovimientoEvent.MovimientoId);
        if (movimiento == null)
        {
            return BadRequest("Movimiento inválido");
        }

        var service = MovimientoServiceFactory.GetService(movimiento.TipoMovimiento, _db, movimiento, _carnetService);
        await service.ProcesaMovimiento(procesaMovimientoEvent);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}