using System.Net;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using CQRSAndMediatorPattern.Domain.Repository;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.DeleteBlog;

public class DeleteBlogHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBlogCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var serviceResult = new ServiceResult();

        var result = await unitOfWork.BlogRepository.DeleteBlog(request.BlogId, cancellationToken);

        if (result == 0)
        {
            serviceResult.StatusCode = HttpStatusCode.NotFound;
            serviceResult.Message = $"Blog with id '{request.BlogId}' is not found.";
        }

        return serviceResult;
    }
}