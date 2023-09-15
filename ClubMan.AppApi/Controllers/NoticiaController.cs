using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class NoticiaController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<NoticiaController> _logger;

    public NoticiaController(IHttpClientFactory factory, ILogger<NoticiaController> logger,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetNoticias")]
    public async Task<IReadOnlyList<Noticia>> Get()
    {
        return await _http.GetFromJsonAsync<IReadOnlyList<Noticia>>("api/Noticia");
    }
    
}