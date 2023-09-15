using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class LocalidadController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<LocalidadController> _logger;

    public LocalidadController(IHttpClientFactory factory, ILogger<LocalidadController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetLocalidades")]
    public async Task<IEnumerable<Localidad>> Get()
    {
        return await _http.GetFromJsonAsync<IEnumerable<Localidad>>("api/Localidad");
    }
}