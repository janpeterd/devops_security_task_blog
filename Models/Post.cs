using Contentful.Core.Models;

namespace techBlog.Models;

public class Post
{
    public string Title { get; set; } = "Temporary title"; // title with default value
    public Document? Body { get; set; } // Contentful document class
    public Asset? Image { get; set; } // Contentful asset class
    // https://www.contentful.com/developers/docs/net/tutorials/rich-text/
    public SystemProperties Sys { get; set; } // properties about a post (date created, ...)
}
