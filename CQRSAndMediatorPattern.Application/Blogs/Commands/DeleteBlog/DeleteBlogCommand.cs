using CQRSAndMediatorPattern.Application.Common.Behaviors;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.DeleteBlog;

public record DeleteBlogCommand(int BlogId) : IRequest<ServiceResult>;