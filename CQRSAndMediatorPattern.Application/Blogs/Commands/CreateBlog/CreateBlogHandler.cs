using System.Net;
using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using CQRSAndMediatorPattern.Application.Common.Mappings;
using CQRSAndMediatorPattern.Domain.Entities;
using CQRSAndMediatorPattern.Domain.Repository;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.CreateBlog;

public class CreateBlogHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateBlogCommand, ServiceResult<GetBlogResponse>>
{
    public async Task<ServiceResult<GetBlogResponse>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var serviceResult = new ServiceResult<GetBlogResponse>();

        var blog = new Blog()
        {
            Name = request.BlogRequest.Name,
            Author = request.BlogRequest.Author,
            Description = request.BlogRequest.Description,
            LastUpdated = DateTime.UtcNow,
        };

        var createdNewBlog = await unitOfWork.BlogRepository.CreateNewBlog(blog, cancellationToken);
        var isComplete = await unitOfWork.Complete();

        if (isComplete == false || createdNewBlog == null)
        {
            serviceResult.StatusCode = HttpStatusCode.BadRequest;
            serviceResult.Message = "Failed to create new blog!";

            return serviceResult;
        }

        serviceResult.Data = createdNewBlog.ToViewModel();

        return serviceResult;
    }
}