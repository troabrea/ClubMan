using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class NoticiaController : TenantController
{
    private readonly ILogger<NoticiaController> _logger;

    public NoticiaController(ILogger<NoticiaController> logger, IDocumentStore store, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetNoticias")]
    public async Task<IReadOnlyList<Noticia>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Noticia>().Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllNoticias")]
    public async Task<IReadOnlyList<Noticia>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Noticia>().ToListAsync();
    }
    
    [HttpPost(Name = "AddOrUpdateNoticia")]
    public async Task<IActionResult> Post([FromBody] Noticia noticia)
    {
        using var session = _store.OpenSession(TenantId);
        session.Store(noticia);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{noticiaId:guid}", Name = "RemoveNoticia")]
    public async Task<IActionResult> Delete(Guid noticiaId)
    {
        using var session = _store.OpenSession(TenantId);
        session.Delete<Noticia>(noticiaId);
        await session.SaveChangesAsync();
        return Ok();
    }
}