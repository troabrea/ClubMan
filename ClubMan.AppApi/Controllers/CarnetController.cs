using System.Net;
using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class CarnetController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<CarnetController> _logger;

    public CarnetController(IHttpClientFactory factory, ILogger<CarnetController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet("{carnetId}", Name = "GetCarnetById")]
    [Produces(typeof(Carnet))]
    public async Task<IActionResult> GetById(string carnetId)
    {
        var result = await _http.GetAsync($"api/Carnet/{carnetId}");
        if(result.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }

        result.EnsureSuccessStatusCode();

        return Ok(await result.Content.ReadFromJsonAsync<Carnet>());
    }
    
    [HttpGet("Socio/{socioId:long}", Name = "GetSocioCarnets")]
    [Produces(typeof(IEnumerable<Carnet>))]
    public async Task<IActionResult> GetSocioCarnets(long socioId)
    {
        return Ok(await _http.GetFromJsonAsync<List<Carnet>>($"api/Carnet/Socio/{socioId}"));
    }
}

