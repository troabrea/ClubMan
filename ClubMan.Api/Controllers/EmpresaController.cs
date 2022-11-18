using ClubMan.Shared.Model;
using Marten;
using Marten.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;

    public EmpresaController(ILogger<EmpresaController> logger)
    {
        _logger = logger;
    }
  
    [HttpGet(Name = "GetEmpresas")]
    [Produces(typeof(IEnumerable<Empresa>))]
    public async Task<IActionResult> Get([FromServices] IQuerySession session)
    {
        var result = await session.Query<Empresa>().ToListAsync();
        return Ok(result);
    }
    
    [HttpGet("{empresaId:guid}", Name = "GetEmpresa")]
    [Produces(typeof(Empresa))]
    public async Task<IActionResult> GetEmpresa([FromServices] IQuerySession session, Guid empresaId)
    {
        var result = await session.LoadAsync<Empresa>(empresaId);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost(Name = "AddOrUpdateEmpresa")]
    public async Task<IActionResult> Post([FromServices] IDocumentSession session, [FromBody] Empresa empresa)
    {
        session.Store(empresa);
        await session.SaveChangesAsync();
        return Ok();
    }
}