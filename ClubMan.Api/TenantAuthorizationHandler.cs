using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace ClubMan.Api;

public class ApiAuth
{
    public string ApiKey { get; set; }
    public List<string> Tenants { get; set; }
}

public class TenantAuthorizationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly ApiAuth _authConfig;

    public TenantAuthorizationHandler(
        IConfiguration configuration,
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    ) : base(options, logger, encoder, clock)
    {
        _authConfig = configuration.GetSection("ApiAuth").Get<ApiAuth>();
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authHeader = Request.Headers["Authorization"].ToString();
        if (authHeader != null && authHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
        {
            var token = !string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer") ? authHeader.Substring("Bearer ".Length).Trim() : string.Empty;
            
            if (!string.IsNullOrEmpty(token) && token == _authConfig.ApiKey) // "C8868CF6-C2DD-4EC4-B00F-0D6F51BD5337")
            {
                var claims = new[] { new Claim(ClaimTypes.Role, "Admin") };
                var identity = new ClaimsIdentity(claims, "Bearer");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
            }

            if (!string.IsNullOrEmpty(token) && _authConfig.Tenants.Contains(token)) // == "3fa85f64-5717-4562-b3fc-2c963f66afa6")
            {
                var claims = new[] { new Claim("tenant", token), new Claim(ClaimTypes.Role, "User") };
                var identity = new ClaimsIdentity(claims, "Bearer");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
            }

            Response.StatusCode = 401;
            Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnetthoughts.net\"");
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        } 
        else
        {
            Response.StatusCode = 401;
            Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnetthoughts.net\"");
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }
    }
}