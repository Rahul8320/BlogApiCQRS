using System.Net;
using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using CQRSAndMediatorPattern.Application.Common.Mappings;
using CQRSAndMediatorPattern.Domain.Repository;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBlogByIdQuery, ServiceResult<GetBlogResponse>>
{
    public async Task<ServiceResult<GetBlogResponse>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var serviceResult = new ServiceResult<GetBlogResponse>();

        var blog = await unitOfWork.BlogRepository.GetBlogById(request.BlogId, cancellationToken);

        if (blog == null)
        {
            serviceResult.StatusCode = HttpStatusCode.NotFound;
            serviceResult.Message = $"Blog with id '{request.BlogId}' is not found in database!";
            return serviceResult;
        }

        serviceResult.Data = blog.ToViewModel();

        return serviceResult;
    }
}
