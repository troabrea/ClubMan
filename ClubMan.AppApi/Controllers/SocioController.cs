using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class SocioController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<SocioController> _logger;

    public SocioController(IHttpClientFactory factory, ILogger<SocioController> logger,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }


    [HttpGet( "{socioId:long}", Name = "GetSocio")]
    public async Task<Socio> GetById(long socioId)
    {
        return await _http.GetFromJsonAsync<Socio>($"api/Socio/{socioId}");
    }
    
}