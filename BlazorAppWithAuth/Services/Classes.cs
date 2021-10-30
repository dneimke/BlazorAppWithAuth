using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorAppWithAuth.Services
{

public class WrapperService1
{
    IHttpContextAccessor _httpContextAccessor;

    public WrapperService1(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }

    public bool UserHasSpecialAccess()
    {
        var principal = _httpContextAccessor.HttpContext.User.Identity;
        return principal.IsAuthenticated;
    }
}

    public class WrapperService2
    {
        public bool UserHasSpecialAccess(ClaimsPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }
    }

    public class WrapperService3
    {
        private readonly AuthenticationStateProvider _provider;

        public WrapperService3(AuthenticationStateProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> UserHasSpecialAccess()
        {
            var principal = await _provider.GetAuthenticationStateAsync();
            if (principal is null)
                return false;

            return principal.User.Identity.IsAuthenticated;
        }
    }
}
