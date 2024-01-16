﻿using BlazorBlog.Shared;
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
            var post = await _http.GetFromJsonAsync<BlogPost>($"api/blog/{url}");

            return post;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var posts = await _http.GetFromJsonAsync<List<BlogPost>>("api/blog");

            return posts;
        }
    }
}
