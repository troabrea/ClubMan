using ClubMan.Shared.Dto;
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
public class ErpController : TenantController
{
    private readonly ClubManContext _db;
    private readonly IErpService _erpService;

    public ErpController(ClubManContext db, IErpService erpService,  ILogger<CarnetController> logger,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _erpService = erpService;
    }
    
    [HttpGet("EstadoDeCuenta/{socioId}", Name = "GetEstadoBySocioId")]
    [Produces(typeof(IEnumerable<FacturaDto>))]
    public async Task<IActionResult> GetEstadoCuentaBySocioId(long socioId)
    {
        var facturas = await _erpService.GetFacturasPendinetesAsync(socioId);
        return Ok(facturas);
    }
}