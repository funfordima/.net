using BlazorBlog.Shared;
using System.Net.Http.Json;

namespace BlazorBlog.Client.Services
{
    public class BlogService : IBlogService
    {
        public HttpClient _http { get; }

        public BlogService(HttpClient http)
        {
            _http = http;
        }


        public async Task<BlogPost> GetBlogPost(string url)
        {
            // var post = await _http.GetFromJsonAsync<BlogPost>($"api/blog/{url}");
            var result = await _http.GetAsync($"api/blog/{url}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();

                Console.WriteLine(message);

                return new BlogPost { Title = message };
            }

            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var posts = await _http.GetFromJsonAsync<List<BlogPost>>("api/blog");

            return posts;
        }

        public async Task<BlogPost> CreateBlogPost(BlogPost post)
        {
            var result = await _http.PostAsJsonAsync("api/blog", post);

            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }
    }
}
