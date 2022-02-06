namespace BlazorAppWithAuth.Services
{
    // https://www.youtube.com/watch?v=Eh4xPgP5PsM
    public class IdentityInformationService
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = "";
    }
}
