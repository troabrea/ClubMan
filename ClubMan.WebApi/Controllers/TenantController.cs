using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.WebApi.Controllers;

[ApiController]
//[Authorize(Roles = "User")]
[AllowAnonymous]
public class TenantController : ControllerBase
{
    private readonly string _tenantId;
    //private IDocumentSession _session;

    public string TenantId => _tenantId;
    //public IDocumentSession Session => _session!;

    public TenantController(IHttpContextAccessor httpContextAccessor)
    {
        _tenantId = string.Empty;
        
        // if (!string.IsNullOrEmpty(_tenantId))
        // {
        //     _session = store.OpenSession(_tenantId);
        // }
    }  
    
}