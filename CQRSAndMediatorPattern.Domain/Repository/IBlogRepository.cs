using CQRSAndMediatorPattern.Domain.Entities;

namespace CQRSAndMediatorPattern.Domain.Repository;

public interface IBlogRepository
{
    Task<List<Blog>> GetAllBlogs(CancellationToken cancellationToken);
    Task<Blog?> GetBlogById(int id, CancellationToken cancellationToken);
    Task<Blog> CreateNewBlog(Blog blog, CancellationToken cancellationToken);
    Task<int> UpdateBlog(Blog blog, CancellationToken cancellationToken);
    Task<int> DeleteBlog(int id, CancellationToken cancellationToken);
}
