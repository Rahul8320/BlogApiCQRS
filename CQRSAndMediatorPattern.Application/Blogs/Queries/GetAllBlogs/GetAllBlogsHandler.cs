using System.Net;
using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using CQRSAndMediatorPattern.Application.Common.Mappings;
using CQRSAndMediatorPattern.Domain.Repository;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Queries.GetAllBlogs;

public class GetAllBlogsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllBlogsQuery, ServiceResult<List<GetBlogResponse>>>
{
    public async Task<ServiceResult<List<GetBlogResponse>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        var serviceResult = new ServiceResult<List<GetBlogResponse>>();

        var blogs = await unitOfWork.BlogRepository.GetAllBlogs(cancellationToken);

        if (blogs == null || blogs.Count == 0)
        {
            serviceResult.StatusCode = HttpStatusCode.NotFound;
            serviceResult.Message = "No blog found in database!";
            return serviceResult;
        }

        serviceResult.Data = blogs.Select(blog => blog.ToViewModel()).ToList();

        return serviceResult;
    }
}
