using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Queries.GetBlogById;

public record GetBlogByIdQuery(int BlogId) : IRequest<ServiceResult<GetBlogResponse>>;
