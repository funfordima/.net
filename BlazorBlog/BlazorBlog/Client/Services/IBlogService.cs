using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services
{
    public interface IBlogService
    {
        List<BlogPost> GetBlogPosts();

        BlogPost GetBlogPost(string url);
    }
}
