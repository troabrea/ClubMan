using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class MensajeController : TenantController
{
    private readonly ClubManContext _db;
    private readonly ILogger<MensajeController> _logger;

    public MensajeController(ClubManContext db, ILogger<MensajeController> logger,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet(Name = "GetMensajes")]
    public async Task<IReadOnlyList<Mensaje>> Get()
    {
        return await _db.Mensajes.Where(x => x.Enviado == false).ToListAsync();
    }
    
    [HttpGet("all", Name = "GetAllMensajes")]
    public async Task<IReadOnlyList<Mensaje>> GetAll()
    {
        return await _db.Mensajes.ToListAsync();
    }
    
    [HttpPost(Name = "AddMensaje")]
    public async Task<IActionResult> Post([FromBody] Mensaje mensaje)
    {
        _db.Add(mensaje);
        await _db.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut(Name = "UpdateMensaje")]
    public async Task<IActionResult> Put([FromBody] Mensaje mensaje)
    {
        var entry = _db.Entry(mensaje);
        if (entry.State == EntityState.Detached)
        {
            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
    
    [HttpDelete("{mensajeId:guid}", Name = "RemoveMensaje")]
    public async Task<IActionResult> Delete(Guid mensajeId)
    {
        var mensaje = _db.Find<Mensaje>(mensajeId);
        if (mensaje != null)
        {
            _db.Remove(mensaje);
            await _db.SaveChangesAsync();
        }
        return Ok();
    }
}