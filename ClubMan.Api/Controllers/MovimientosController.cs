using ClubMan.Api.Services;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class MovimientosController : TenantController
{
    private readonly ILogger<MovimientosController> _logger;
    private readonly ICarnetService _carnetService;

    public MovimientosController(ILogger<MovimientosController> logger, IDocumentStore store, ICarnetService carnetService,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, store)
    {
        _logger = logger;
        _carnetService = carnetService;
    }
    [HttpGet(Name = "GetMovimientos")]
    public async Task<IReadOnlyList<MovimientoSocio>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<MovimientoSocio>().Where(x => x.Estatus == EstatusMovimiento.Pendiente).ToListAsync();
    }
    
    [HttpGet("socio/{socioId:long}", Name = "GetMovimientosSocio")]
    public async Task<IReadOnlyList<MovimientoSocio>> GetBySocio(long socioId)
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<MovimientoSocio>().Where(x => x.SocioId == socioId).ToListAsync();
    }

    [HttpPost("procesar", Name = "ProcesarMovimiento")]
    public async Task<IActionResult> ProcesaMovimiento([FromBody] ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var movimiento = await session.LoadAsync<MovimientoSocio>(procesaMovimientoEvent.MovimientoId);
        if (movimiento == null)
        {
            return BadRequest("Movimiento inválido");
        }

        var service = MovimientoServiceFactory.GetService(movimiento.TipoMovimiento, session, movimiento, _carnetService);
        await service.ProcesaMovimiento(procesaMovimientoEvent);
        await session.SaveChangesAsync();
        return NoContent();
    }
}