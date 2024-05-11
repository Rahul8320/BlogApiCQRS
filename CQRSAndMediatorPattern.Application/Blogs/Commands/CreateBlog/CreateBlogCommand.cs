using CQRSAndMediatorPattern.Application.Blogs.Models.Requests;
using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.CreateBlog;

public record CreateBlogCommand(CreateBlogRequest BlogRequest) : IRequest<ServiceResult<GetBlogResponse>>;