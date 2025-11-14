using BlogApi.Model;

namespace BlogApi.Database.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync(string? term);
        Task<Post?> GetAsync(int id);
        Task<Post?> AddAsync(Post post);
        Task<Post?> UpdateAsync(int id, Post post);
        Task<bool> DeleteAsync(int id);

    }
}
