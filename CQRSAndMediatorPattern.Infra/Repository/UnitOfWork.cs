using CQRSAndMediatorPattern.Domain.Repository;
using CQRSAndMediatorPattern.Infra.Data;

namespace CQRSAndMediatorPattern.Infra;

public class UnitOfWork(BlogDbContext dbContext) : IUnitOfWork, IDisposable
{
    public IBlogRepository BlogRepository { get; } = new BlogRepository(dbContext);

    public async Task<bool> Complete()
    {
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
