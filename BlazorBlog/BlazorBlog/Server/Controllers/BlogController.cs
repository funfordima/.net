using BlazorBlog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>()
        {
            new BlogPost
            {
                Url = "new-tutorial",
                Title = "A new tuttorial about Blazor with WebAPI",
                Description = "This is a new tutorial, showing you how to build a blog with Blazor",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            },
            new BlogPost
            {
                Url = "first-post",
                Title = "My first blog post with WebAPI",
                Description = "Hi! This is my new shiny blog. Enjoy!",
                Content = "Sed risus pretium quam vulputate dignissim suspendisse in. Mi eget mauris pharetra et. Sagittis nisl rhoncus mattis rhoncus. Erat velit scelerisque in dictum non consectetur a. Cursus mattis molestie a iaculis. Elementum nisi quis eleifend quam adipiscing vitae proin sagittis. Nulla porttitor massa id neque aliquam. Quis viverra nibh cras pulvinar mattis nunc sed. Convallis posuere morbi leo urna. Gravida rutrum quisque non tellus orci ac auctor augue. Dapibus ultrices in iaculis nunc sed augue lacus viverra. Arcu felis bibendum ut tristique et egestas quis. Lectus urna duis convallis convallis tellus id interdum velit.",
            },
        };

        [HttpGet]
        public ActionResult<List<BlogPost>> GetBlogPosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> GetBlogPost(string Url)
        {
            var post = Posts.FirstOrDefault((p) => p.Url.ToLower().Equals(Url.ToLower()));

            if (post == null)
            {
                return NotFound("This post does not exist.");
            }
            return Ok(post);
        }
    }
}
