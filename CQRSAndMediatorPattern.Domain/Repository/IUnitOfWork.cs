namespace CQRSAndMediatorPattern.Domain.Repository;

public interface IUnitOfWork
{
    IBlogRepository BlogRepository { get; }

    Task<bool> Complete();
}
