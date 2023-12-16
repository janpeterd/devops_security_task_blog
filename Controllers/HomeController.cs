using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using techBlog.Models;
using Contentful.Core;
using System.Web;

namespace techBlog.Controllers;

public class HomeController : Controller // This controller class inherits from the controller base class
{
    private readonly ILogger<HomeController> _logger;
    private readonly IContentfulClient _client; // client for calling Contentful API

    public HomeController(ILogger<HomeController> logger, IContentfulClient client)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<IActionResult> Index() // This method will execute when there is a request to /Home/Index
    {
        var posts = await _client.GetEntries<Post>(); // Get all entries from contentful
        return View(posts); // Return the posts view
    }

    public IActionResult PostNotFound() // This method is used when a post is not found
    {
        return View();
    }
    public async Task<Post> GetPostByTitle(string title) // This is a helper function used below
    {
        var entries = await _client.GetEntries<Post>(); // Get all posts
        return entries.FirstOrDefault(post => post.Title == title); // Return the first match with title or a default post (empty)
    }



    [Route("posts/{title}")] // Dynamic route to display posts
    public async Task<IActionResult> Post(string title)
    {
        var decodedTitle = HttpUtility.UrlDecode(title); // the title is urlencoded by the view, so decode first
        var allPosts = await _client.GetEntries<Post>(); // Get all posts (needed for other metadata)
        var post = await GetPostByTitle(decodedTitle); // Get the post matching the title
        if (post == null) // no post found, return postnotfound view
        {
            return Redirect("~/Home/PostNotFound");
        }
        ViewBag.allPosts = allPosts; // Add allposts to the 'viewbag', which we can access in the view
        return View(post); // return the view
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() // Error route
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}