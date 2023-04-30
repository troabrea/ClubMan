using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class NoticiaController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<NoticiaController> _logger;

    public NoticiaController(ClubManContext db, ILogger<NoticiaController> logger,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetNoticias")]
    public async Task<IReadOnlyList<Noticia>> Get()
    {
        return await _db.Noticias.Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllNoticias")]
    public async Task<IReadOnlyList<Noticia>> GetAll()
    {
        return await _db.Noticias.ToListAsync();
    }
    
    [HttpPost(Name = "AddNoticia")]
    public async Task<IActionResult> Post([FromBody] Noticia noticia)
    {
        _db.Add(noticia);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateNoticia")]
    public async Task<IActionResult> Put([FromBody] Noticia noticia)
    {
        var entry = _db.Entry(noticia);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpDelete("{noticiaId:guid}", Name = "RemoveNoticia")]
    public async Task<IActionResult> Delete(Guid noticiaId)
    {
        var noticia = _db.Find<Noticia>(noticiaId);
        if (noticia != null)
        {
            _db.Remove(noticia);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}