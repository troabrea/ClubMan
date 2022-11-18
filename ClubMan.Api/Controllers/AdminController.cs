using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly Guid _empresaKey;
    public AdminController(ILogger<EmpresaController> logger, IHttpContextAccessor contextAccessor)
    {
        var authHeader = contextAccessor.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
        var empresaKey = !string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer") ? authHeader.Substring("Bearer ".Length).Trim() : string.Empty;
        _empresaKey = Guid.Parse(empresaKey);
        _logger = logger;
    }
    
    [HttpGet("Preferencias", Name = "GetPreferencias")]
    [Produces(typeof(Empresa))]
    public async Task<IActionResult> GetPreferencias([FromServices] IQuerySession session)
    {
        
        var result = await session.LoadAsync<Empresa>(_empresaKey);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost("Preferencias",Name = "AddOrUpdatePreferencias")]
    public async Task<IActionResult> Post([FromServices] IDocumentSession session, [FromBody] Empresa empresa)
    {
        if (empresa.Id != _empresaKey)
        {
            return Unauthorized();
        }
        session.Store(empresa);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpGet("Usuarios", Name = "GetUsuariosEmpresa")]
    public async Task<IActionResult> GetUsuarios([FromServices] IQuerySession session)
    {
        var result = await session.Query<Usuario>().Where(x => x.EmpresaId == _empresaKey).ToListAsync();
        return Ok(result);
    }
    
    [HttpPost("Usuarios",Name = "AddOrUpdateUsuarioEmpresa")]
    public async Task<IActionResult> PostUsuario([FromServices] IDocumentSession session, [FromBody] Usuario usuario)
    {
        if (usuario.EmpresaId != _empresaKey)
        {
            return Unauthorized();
        }
        session.Store(usuario);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    
    [HttpGet("Politicas", Name = "GetPoliticasEmpresa")]
    public async Task<IActionResult> GetPoliticas([FromServices] IDocumentSession session)
    {
        var result = await session.Query<Politica>().FirstOrDefaultAsync();
        if (result == null)
        {
            result = new Politica();
            session.Store(result);
            await session.SaveChangesAsync();
        }
        return Ok(result);
    }
    
    [HttpPost("Politicas",Name = "AddOrUpdatePolicitasEmpresa")]
    public async Task<IActionResult> PostUsuario([FromServices] IDocumentSession session, [FromBody] Politica politica)
    {
        session.Store(politica);
        await session.SaveChangesAsync();
        return Ok();
    }
}