using BlogApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private static List<Post> _posts = new List<Post>();

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _posts;
        }

        [HttpGet("{id}")]
        public IEnumerable<Post> GetPost(int id)
        {
            return _posts.Where(p=>p.Id ==id);
        }

        [HttpPost]
        public void Post(Post post) {
            Post p = new Post()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Category = post.Category,
                Tags = post.Tags,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                UpdatedAt = DateOnly.FromDateTime(DateTime.Now)
            };
            _posts.Add(p);
        }
    }
}
