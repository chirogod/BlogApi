using BlogApi.Database.Interfaces;
using BlogApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? term)
        {
            try
            {
                IEnumerable<Post> posts = await _postRepository.GetAllAsync(term);
                return Ok(posts);
            }
            catch (Exception ex) {
                return StatusCode(400, $"Bad request: {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                Post? post = await _postRepository.GetAsync(id);
                if(post == null)
                {
                    return NotFound($"Post con id '{id}' no encontrado.");
                }
                else
                {
                    return Ok(post);
                }

            }catch(Exception ex)
            {
                return StatusCode(400, $"Bad request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post) {
            try
            {
                Post p = new Post()
                {
                    Title = post.Title,
                    Content = post.Content,
                    Category = post.Category,
                    Tags = post.Tags,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now)
                };
                Post? addedPost = await _postRepository.AddAsync(p);
                return StatusCode(201, addedPost);
            }
            catch (Exception ex) {
                return StatusCode(400, $"Bad request: {ex.Message}");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Post post)
        {
            try
            {
                Post p = new Post()
                {
                    Title = post.Title,
                    Content = post.Content,
                    Category = post.Category,
                    Tags = post.Tags,
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now)
                };
                Post? updatedPost = await _postRepository.UpdateAsync(id, p);
                if(updatedPost == null)
                {
                    return NotFound($"Post con id '{id}' no encontrado.");
                }

                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Bad request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                bool deleted = await _postRepository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound($"El post con Id {id} no fue encontrado.");
                }
                
            }catch(Exception ex)
            {
                return StatusCode(400, $"Bad request: {ex.Message}");
            }
            
             
        }

    }
}
