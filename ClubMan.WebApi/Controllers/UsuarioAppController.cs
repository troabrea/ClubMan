using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[AllowAnonymous]
[Route("api/[controller]")]
public class UsuarioAppController : ControllerBase
{
    private readonly ClubManContext _db;
    private readonly ILogger<UsuarioAppController> _logger;

    public UsuarioAppController(ClubManContext db, ILogger<UsuarioAppController> logger)
    {
        _db = db;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetUsuariosApp")]
    [Produces(typeof(IEnumerable<UsuarioApp>))]
    public async Task<IActionResult> GetUsuariosApp()
    {
        return Ok(await _db.UsuariosApp.ToListAsync());
    }
    
    [HttpGet("{usuarioId:guid}", Name = "GetUsuarioApp")]
    [Produces(typeof(UsuarioApp))]
    public async Task<IActionResult> GetUsuarioApp(Guid usuarioId)
    {
        var result = await _db.FindAsync<UsuarioApp>(usuarioId);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost("login", Name = "LoginAppUser")]
    [Produces(typeof(LoggedUserViewModel))]
    public async Task<IActionResult> LoginAppUser([FromBody] LoginViewModel loginViewModel)
    {
        var user = await _db.UsuariosApp.Where(x => x.UsuarioId == loginViewModel.UsuarioId && x.ClaveHash == loginViewModel.Clave).SingleOrDefaultAsync();
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
    
    [HttpPost(Name = "AddUsuarioApp")]
    public async Task<IActionResult> Post([FromBody] UsuarioApp usuario)
    {
        _db.Add(usuario);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPut(Name = "UpdateUsuarioApp")]
    public async Task<IActionResult> Put([FromBody] UsuarioApp usuario)
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