using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Queries.GetAllBlogs;

public record GetAllBlogsQuery : IRequest<ServiceResult<List<GetBlogResponse>>>;