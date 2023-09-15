using ClubMan.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.AppApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
[Route("api/[controller]")]
public class InstalacionController : TenantController
{
    private readonly HttpClient _http;
    private readonly ILogger<InstalacionController> _logger;

    public InstalacionController(IHttpClientFactory factory, ILogger<InstalacionController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _http = factory.CreateClient("WebApi");
        _logger = logger;
    }

    [HttpGet(Name = "GetInstalaciones")]
    public async Task<IEnumerable<InstalacionViewModel>> Get()
    {
        return await _http.GetFromJsonAsync<IEnumerable<InstalacionViewModel>>("api/Instalacion");
    }
}