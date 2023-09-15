using System.Net;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[AllowAnonymous]
[Route("api/[controller]")]
public class UsuarioAppController : ControllerBase
{
    private readonly HttpClient _http;
    private readonly ILogger<UsuarioAppController> _logger;

    public UsuarioAppController(IHttpClientFactory factory, ILogger<UsuarioAppController> logger)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }
    
    [HttpPost("login", Name = "LoginAppUser")]
    [Produces(typeof(LoggedUserViewModel))]
    public async Task<IActionResult> LoginAppUser([FromBody] LoginViewModel loginViewModel)
    {
        var result = await _http.PostAsJsonAsync("api/UsuarioApp/login", loginViewModel);
        if (result.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (result.StatusCode == HttpStatusCode.BadRequest) return BadRequest();

        result.EnsureSuccessStatusCode();
        
        return  Ok( await result.Content.ReadFromJsonAsync<LoggedUserViewModel>() );
    }
    
}