using BlazorBlog.Server.Data;
using BlazorBlog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public DataContext _context { get; }

        public BlogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> GetBlogPosts()
        {
            return Ok(_context.BlogPosts);
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> GetBlogPost(string Url)
        {
            var post = _context.BlogPosts.FirstOrDefault((p) => p.Url.ToLower().Equals(Url.ToLower()));

            if (post == null)
            {
                return NotFound("This post does not exist.");
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreatePost(BlogPost post)
        {
            _context.Add(post);

            await _context.SaveChangesAsync();

            return post;
        }
    }
}
