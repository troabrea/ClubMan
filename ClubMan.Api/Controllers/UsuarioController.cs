using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetUsuarios")]
    [Produces(typeof(IEnumerable<Usuario>))]
    public async Task<IActionResult> GetUsuarios([FromServices] IQuerySession sessiond)
    {
        return Ok(await sessiond.Query<Usuario>().ToListAsync());
    }
    
    [HttpGet("{usuarioId:guid}", Name = "GetUsuario")]
    [Produces(typeof(Usuario))]
    public async Task<IActionResult> GetUsuario([FromServices] IQuerySession session, Guid usuarioId)
    {
        var result = await session.LoadAsync<Usuario>(usuarioId);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost("login", Name = "Login")]
    [Produces(typeof(LoggedUserViewModel))]
    public async Task<IActionResult> LoginUser([FromServices] IQuerySession session, [FromBody] LoginViewModel loginViewModel)
    {
        var user = await session.Query<Usuario>().Where(x => x.UsuarioId == loginViewModel.UsuarioId && x.ClaveHash == loginViewModel.Clave).SingleOrDefaultAsync();
        if (user == null) return NotFound();
        var empresa = await session.Query<Empresa>().Where(x => x.Id == user.EmpresaId).SingleOrDefaultAsync();
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
    
    [HttpPost(Name = "AddOrUpdateUsuario")]
    public async Task<IActionResult> Post([FromServices] IDocumentSession session, [FromBody] Usuario usuario)
    {
        session.Store(usuario);
        await session.SaveChangesAsync();
        return Ok();
    }
}