namespace BlazorAppWithAuth.Services
{
    public class WrapperService
    {
        private readonly IdentityInformationService _informationService;

        public WrapperService(IdentityInformationService informationService)
        {
            _informationService = informationService;
        }

        
        public bool UserHasSpecialAccess()
        {
            return _informationService.IsAuthenticated;
        }
    }
}
