namespace ProjectFishWorksWebApp.Services
{
    public class FakeAuthService
    {
        public string GetUserId()
        {
            // Return a fake user ID for debug mode
            return "debug-user";
        }

        public string GetEmail()
        {
            // Optional: return a fake email for UI
            return "debug@example.com";
        }
    }
}
