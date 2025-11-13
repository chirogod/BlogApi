using BlogApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Database
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }

    }
}
