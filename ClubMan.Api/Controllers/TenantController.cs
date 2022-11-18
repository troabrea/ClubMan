using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
public class TenantController : ControllerBase
{
    private readonly string _tenantId;
    //private IDocumentSession _session;

    public string TenantId => _tenantId;
    //public IDocumentSession Session => _session!;

    public IDocumentStore _store;
    
    public TenantController(IHttpContextAccessor httpContextAccessor, IDocumentStore store)
    {
        _tenantId = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "tenant")?.Value ?? string.Empty;
        _store = store;
        // if (!string.IsNullOrEmpty(_tenantId))
        // {
        //     _session = store.OpenSession(_tenantId);
        // }
    }  
    
}