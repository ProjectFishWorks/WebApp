using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ProjectFishWorksWebApp.Services
{
    public class FakeAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Create a fake identity for Debug mode
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "DebugUser"),
                new Claim("sub", "debug-client-id")
            }, "FakeAuth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
