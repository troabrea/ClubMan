using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class PreguntaController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<PreguntaController> _logger;

    public PreguntaController(IHttpClientFactory factory, ILogger<PreguntaController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetPreguntas")]
    public async Task<IReadOnlyList<Pregunta>> Get()
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<Pregunta>>("api/Pregunta");
    }
    
}