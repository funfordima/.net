using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetBlogPosts();

        Task<BlogPost> GetBlogPost(string url);
    }
}
