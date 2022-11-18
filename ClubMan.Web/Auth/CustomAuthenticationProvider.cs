using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClubMan.Web.Auth;

public class CustomAuthenticationProvider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _localStorageService;

    public CustomAuthenticationProvider(ProtectedSessionStorage localStorageService)
    {
        _localStorageService = localStorageService;
    }
    
    private readonly ClaimsPrincipal _anonymous = new (new ClaimsIdentity());
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSessionStoreageResult = await _localStorageService.GetAsync<UserSession>("UserSession");
            var userSession = userSessionStoreageResult.Success ? userSessionStoreageResult.Value : null;
            if (userSession == null) return new AuthenticationState(_anonymous);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.NameIdentifier, userSession.ClubKey),
                new Claim(ClaimTypes.GivenName, userSession.ClubName),
                new Claim(ClaimTypes.Sid, userSession.UserId),
                new Claim(ClaimTypes.Role, userSession.Role),
                new Claim("clubman.PrimaryColor", userSession.PrimaryColor ),
                new Claim("clubman.SecondaryColor", userSession.SecondaryColor ),
                new Claim("clubman.LogoUrl", userSession.LogoUrl )
            }, "CustomAuth"));
            
            return await  Task.FromResult( new AuthenticationState(claimsPrincipal) );
        }
        catch 
        {
            return new AuthenticationState(_anonymous);
        }
    }

    public async Task UpdateAuthenticationState(UserSession userSession)
    {
        ClaimsPrincipal claimsPrincipal;
        if (userSession != null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.NameIdentifier, userSession.ClubKey),
                new Claim(ClaimTypes.GivenName, userSession.ClubName),
                new Claim(ClaimTypes.Sid, userSession.UserId),
                new Claim(ClaimTypes.Role, userSession.Role ),
                new Claim("clubman.PrimaryColor", userSession.PrimaryColor ),
                new Claim("clubman.SecondaryColor", userSession.SecondaryColor ),
                new Claim("clubman.LogoUrl", userSession.LogoUrl )
            }, "CustomAuth"));
            await _localStorageService.SetAsync("UserSession", userSession);
        }
        else
        {
            await _localStorageService.DeleteAsync("UserSession");
            claimsPrincipal = _anonymous;
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}