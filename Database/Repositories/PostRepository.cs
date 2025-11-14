using BlogApi.Database.Interfaces;
using BlogApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlogApi.Database.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostContext _context;
        public PostRepository(PostContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync(string? term)
        {

            if (string.IsNullOrEmpty(term))
            {
                return await _context.Posts.ToListAsync();
            }
            else
            {
                return await _context.Posts.Where(p => p.Category == term || p.Content == term || p.Title == term).ToListAsync();
            }
               
        }

        public async Task<Post?> GetAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }
        public async Task<Post> AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task<Post?> UpdateAsync(int id, Post post)
        {
            var p = await _context.Posts.FindAsync(id);

            if(p == null)
            {
                return null;
            }

            p.Title = post.Title;
            p.Content  = post.Content;
            p.Category = post.Category;
            p.Tags = post.Tags;
            p.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            
            await _context.SaveChangesAsync();
            return p;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post == null)
            {
                return false;
            }
            _context.Posts.Remove(post);    
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
