using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace ClubMan.WebApi.Controllers;


[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class CobroController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<CobroController> _logger;

    public CobroController(ClubManContext db, ILogger<CobroController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet("{cobroId:long}")]
    [Produces(typeof(Cobro))]
    public async Task<IActionResult> GetCobroById(long cobroId)
    {
        return Ok(await _db.Cobros.SingleOrDefaultAsync(x => x.Id == cobroId));
    }
    
    [HttpPost(Name = "AddCobro")]
    public async Task<IActionResult> Post([FromBody] Cobro cobro)
    {
        _db.Add(cobro);
        await _db.SaveChangesAsync();
        return Ok(cobro);
    }
    [HttpPut(Name = "UpdateCobro")]
    public async Task<IActionResult> Put([FromBody] Cobro cobro)
    {
        var dbCobro = await _db.Cobros.SingleOrDefaultAsync(x => x.Id == cobro.Id);
        if (dbCobro == null)
        {
            return NotFound();
        }
        
        dbCobro.Estatus = cobro.Estatus;
        dbCobro.Mensaje = cobro.Mensaje;
        dbCobro.NumeroTarjeta = cobro.NumeroTarjeta;
        dbCobro.NumeroConfirmacion = cobro.NumeroConfirmacion;
        dbCobro.ConfirmadoEn = cobro.ConfirmadoEn;
        
        await _db.SaveChangesAsync();
        return Ok(cobro);
    }
}
