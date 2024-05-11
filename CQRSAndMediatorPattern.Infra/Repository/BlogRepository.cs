using CQRSAndMediatorPattern.Domain.Entities;
using CQRSAndMediatorPattern.Domain.Repository;
using CQRSAndMediatorPattern.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatorPattern.Infra;

public class BlogRepository(BlogDbContext dbContext) : IBlogRepository
{
    public async Task<List<Blog>> GetAllBlogs(CancellationToken cancellationToken)
    {
        return await dbContext.Blogs.ToListAsync(cancellationToken);
    }

    public async Task<Blog?> GetBlogById(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Blog> CreateNewBlog(Blog blog, CancellationToken cancellationToken)
    {
        await dbContext.Blogs.AddAsync(blog, cancellationToken);

        return blog;
    }

    public async Task<int> UpdateBlog(Blog blog, CancellationToken cancellationToken)
    {
        dbContext.Update(blog);
        await Task.CompletedTask;
        return blog.Id;
    }

    public async Task<int> DeleteBlog(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Blogs.Where(blog => blog.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}
