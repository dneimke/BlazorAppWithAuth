using System.Security.Claims;

namespace BlazorAppWithAuth.Services
{
    public class UserContext
    {
        HttpContext _httpContext;
        ClaimsPrincipal _principal;

        public UserContext(IHttpContextAccessor httpContext) => _httpContext = httpContext.HttpContext;
        public UserContext(ClaimsPrincipal principal) => _principal = principal;
        
        public bool IsAuthenticated {
            get
			{
                if (_principal is null)
                {
                    _principal = _httpContext.User;

                }

                return _principal.Identity.IsAuthenticated;
            }
        }
    }


    public class WrapperService
    {
        UserContext _userContext;

        public WrapperService(UserContext context)
        {
            _userContext = context;
        }

        public bool UserHasSpecialAccess()
        {
            return _userContext.IsAuthenticated;
        }
    }

    public class WrapperService2
    {
        public WrapperService2()
        {
           
        }

        public bool UserHasSpecialAccess(UserContext context)
        {
            return context.IsAuthenticated;
        }
    }
}
