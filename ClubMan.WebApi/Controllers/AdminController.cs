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
public class AdminController : ControllerBase
{
    private readonly ClubManContext _db;
    private readonly ILogger<AdminController> _logger;
    // private readonly Guid _empresaKey;
    public AdminController(ClubManContext db, ILogger<AdminController> logger)
    {
        _db = db;
        _logger = logger;
    }
    
    [HttpGet("Preferencias", Name = "GetPreferencias")]
    [Produces(typeof(Empresa))]
    public async Task<IActionResult> GetPreferencias()
    {
        
        var result = await _db.Empresas.FirstOrDefaultAsync();
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost("Preferencias",Name = "UpdatePreferencias")]
    public async Task<IActionResult> Post([FromBody] Empresa empresa)
    {
        // if (empresa.Id != _empresaKey)
        // {
        //     return Unauthorized();
        // }
        var entry = _db.Entry(empresa);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpGet("Usuarios", Name = "GetUsuariosEmpresa")]
    public async Task<IActionResult> GetUsuarios()
    {
        var result = await _db.Usuarios.ToListAsync();
        return Ok(result);
    }
    
    [HttpPost("Usuarios",Name = "UpdateUsuarioEmpresa")]
    public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
    {
        var entry = _db.Entry(usuario);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    
    [HttpGet("Politicas", Name = "GetPoliticasEmpresa")]
    public async Task<IActionResult> GetPoliticas()
    {
        var result = await _db.Politicas.FirstOrDefaultAsync();
        if (result == null)
        {
            result = new Politica();
            _db.Add(result);
            await _db.SaveChangesAsync();
        }
        return Ok(result);
    }
    
    [HttpPost("Politicas",Name = "UpdatePolicitasEmpresa")]
    public async Task<IActionResult> PostUsuario([FromBody] Politica politica)
    {
        var entry = _db.Entry(politica);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        } 
        
        return Ok();
    }
}