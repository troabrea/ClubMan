using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[AllowAnonymous]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ClubManContext _db;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ClubManContext db, ILogger<UsuarioController> logger)
    {
        _db = db;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetUsuarios")]
    [Produces(typeof(IEnumerable<Usuario>))]
    public async Task<IActionResult> GetUsuarios()
    {
        return Ok(await _db.Usuarios.ToListAsync());
    }
    
    [HttpGet("{usuarioId:guid}", Name = "GetUsuario")]
    [Produces(typeof(Usuario))]
    public async Task<IActionResult> GetUsuario(Guid usuarioId)
    {
        var result = await _db.FindAsync<Usuario>(usuarioId);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost("login", Name = "Login")]
    [Produces(typeof(LoggedUserViewModel))]
    public async Task<IActionResult> LoginUser([FromBody] LoginViewModel loginViewModel)
    {
        var user = await _db.Usuarios.Where(x => x.UsuarioId == loginViewModel.UsuarioId && x.ClaveHash == loginViewModel.Clave).SingleOrDefaultAsync();
        if (user == null) return NotFound();
        var empresa = await _db.Empresas.Where(x => x.Id == user.EmpresaId).SingleOrDefaultAsync();
        if (empresa == null) return BadRequest();
        return  Ok(new LoggedUserViewModel()
        {
            Id = user.Id,
            EmpresaId = user.EmpresaId,
            NombreUsuario = user.Nombre,
            UsuarioId = user.UsuarioId,
            Rol = user.Rol
        });
    }
    
    [HttpPost(Name = "AddUsuario")]
    public async Task<IActionResult> Post([FromBody] Usuario usuario)
    {
        _db.Add(usuario);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPut(Name = "UpdateUsuario")]
    public async Task<IActionResult> Put([FromBody] Usuario usuario)
    {
        var entry = _db.Entry(usuario);
        if (entry.State != EntityState.Detached || entry.State == EntityState.Unchanged)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        } 
       
        return Ok();
    }
}