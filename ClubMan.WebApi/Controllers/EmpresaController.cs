using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[AllowAnonymous]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly ClubManContext _db;
    private readonly ILogger<EmpresaController> _logger;

    public EmpresaController(ClubManContext db, ILogger<EmpresaController> logger)
    {
        _db = db;
        _logger = logger;
    }
  
    [HttpGet(Name = "GetEmpresas")]
    [Produces(typeof(IEnumerable<Empresa>))]
    public async Task<IActionResult> Get()
    {
        var result = await _db.Empresas.ToListAsync();
        return Ok(result);
    }
    
    [HttpGet("{empresaId:guid}", Name = "GetEmpresa")]
    [Produces(typeof(Empresa))]
    public async Task<IActionResult> GetEmpresa(Guid empresaId)
    {
        var result = await _db.Empresas.FindAsync(empresaId);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost(Name = "AddEmpresa")]
    public async Task<IActionResult> Post([FromBody] Empresa empresa)
    {
        _db.Add(empresa);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateEmpresa")]
    public async Task<IActionResult> Put([FromBody] Empresa empresa)
    {
        var entry = _db.Entry(empresa);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}