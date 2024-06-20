using Microsoft.AspNetCore.Mvc;
using Reddit;

namespace SubReddit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedditController : ControllerBase
    {
      
        private readonly ILogger<RedditController> _logger;

        public RedditController(ILogger<RedditController> logger)
        {
            _logger = logger;
        }

        private readonly IConfiguration _configuration;

        public RedditController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetSubReddit")]
        public async Task<IActionResult> GetSubRedditAsync()
        {
            var clientId = _configuration["RedditApi:ClientId"];
            var clientSecret = _configuration["RedditApi:ClientSecret"];
            //// Create a Reddit client with your credentials.
            var reddit = new RedditClient(clientId, clientSecret);

            // Specify the subreddit you want to retrieve posts from.
            var subredditName = "nba"; // Change this to your desired subreddit.

            // Fetch the top posts from the subreddit.
            var subreddit = reddit.Subreddit(subredditName).About().SubscribeAsync();
           
            //var topPosts = if (subreddit != null)
            //{ .Posts.Top; }

            // Process the top posts (e.g., extract titles, scores, etc.).
            //var postTitles = topPosts.Select(post => post.Title);

            // Return the post titles (you can customize this part).
            return Ok(subreddit);
          
          
            
        }
    }
}
