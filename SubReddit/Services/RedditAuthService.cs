using Reddit;
using Reddit.AuthTokenRetriever;
using SubReddit.Interfaces;

namespace SubReddit.Services
{
    public class RedditAuthService : IRedditAuthService
    {
        private readonly RedditClient _redditClient;
        private readonly AuthTokenRetrieverLib _authTokenRetrieverLib;

        public RedditAuthService(string appId, string appSecret)
        {
            _authTokenRetrieverLib = new AuthTokenRetrieverLib(appId, appSecret, 8080);
        }
        public async Task<string> GetAccessTokenAsync()
        {
            try
            {
                // Retrieve the access token.
                var accessToken = await _authTokenRetrieverLib.AwaitCallback();
                return accessToken;
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display, etc.).
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
