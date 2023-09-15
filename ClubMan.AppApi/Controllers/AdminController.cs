using System.Net;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly HttpClient _http;
    private readonly ILogger<AdminController> _logger;
    // private readonly Guid _empresaKey;
    public AdminController(IHttpClientFactory factory, ILogger<AdminController> logger)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }
    
    [HttpGet("Preferencias", Name = "GetPreferencias")]
    [Produces(typeof(Empresa))]
    public async Task<IActionResult> GetPreferencias()
    {
        var result = await _http.GetAsync("api/Admin/Preferencias");
        if (result.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }

        result.EnsureSuccessStatusCode();

        return Ok(await result.Content.ReadFromJsonAsync<Empresa>());
    }
}