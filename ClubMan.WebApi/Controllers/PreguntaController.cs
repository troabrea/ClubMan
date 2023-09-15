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
public class PreguntaController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<PreguntaController> _logger;

    public PreguntaController(ClubManContext db, ILogger<PreguntaController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetPreguntas")]
    public async Task<IReadOnlyList<Pregunta>> Get()
    {
        return await _db.Preguntas.Where(x => x.Publicado == true).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllPreguntas")]
    public async Task<IReadOnlyList<Pregunta>> GetAll()
    {
        return await _db.Preguntas.ToListAsync();
    }
    
    [HttpPost(Name = "AddPregunta")]
    public async Task<IActionResult> Post([FromBody] Pregunta pregunta)
    {
        _db.Add(pregunta);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPut(Name = "UpdatePregunta")]
    public async Task<IActionResult> Put([FromBody] Pregunta pregunta)
    {
        var entry = _db.Entry(pregunta);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    [HttpDelete("{preguntaId:guid}", Name = "RemovePregunta")]
    public async Task<IActionResult> Delete(Guid preguntaId)
    {
        var pregunta = _db.Find<Pregunta>(preguntaId);
        if (pregunta != null)
        {
            _db.Remove(pregunta);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}