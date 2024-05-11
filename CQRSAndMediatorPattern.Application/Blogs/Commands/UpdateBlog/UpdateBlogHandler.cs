using System.Net;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using CQRSAndMediatorPattern.Domain.Repository;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.UpdateBlog;

public class UpdateBlogHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateBlogCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var serviceResult = new ServiceResult<int>();

        // fetch blog with id
        var existingBlog = await unitOfWork.BlogRepository.GetBlogById(request.BlogRequest.Id, cancellationToken);

        if (existingBlog == null)
        {
            serviceResult.StatusCode = HttpStatusCode.NotFound;
            serviceResult.Message = $"Blog with id '{request.BlogRequest.Id}' not found in database.";

            return serviceResult;
        }

        // update existing blog data
        existingBlog.Name = request.BlogRequest.Name;
        existingBlog.Description = request.BlogRequest.Description;
        existingBlog.Author = request.BlogRequest.Author;
        existingBlog.LastUpdated = DateTime.UtcNow;

        await unitOfWork.BlogRepository.UpdateBlog(existingBlog, cancellationToken);
        var isComplete = await unitOfWork.Complete();

        if (isComplete == false)
        {
            serviceResult.StatusCode = HttpStatusCode.BadRequest;
            serviceResult.Message = "Failed to update new blog!";

            return serviceResult;
        }

        return serviceResult;
    }
}
