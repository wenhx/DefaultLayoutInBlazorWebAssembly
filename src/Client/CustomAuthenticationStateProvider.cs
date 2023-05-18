using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

internal class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(BuildNotAuthenticatedUser());
        //var state = new AuthenticationState(BuildAuthenticatedUser());
        return Task.FromResult(state);
    }

    ClaimsPrincipal BuildAuthenticatedUser()
    {
        var claims = new List<Claim>
        {
           new Claim(ClaimTypes.Name, "Admin"),
           new Claim(ClaimTypes.Email, "admin@test.com"),
           new Claim(ClaimTypes.Role, "Administrators")
        };
        var identity = new ClaimsIdentity(claims, "TokenAuthentication");
        var principal = new ClaimsPrincipal(identity);
        return principal;
    }

    ClaimsPrincipal BuildNotAuthenticatedUser()
    {
        var identity = new ClaimsIdentity();
        var principal = new ClaimsPrincipal(identity);
        return principal;
    }
}