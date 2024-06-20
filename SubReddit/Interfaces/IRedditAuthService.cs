namespace SubReddit.Interfaces
{
    public interface IRedditAuthService
    {
        Task<string> GetAccessTokenAsync();
    }
}
