using CQRSAndMediatorPattern.Application.Blogs.Models.Requests;
using CQRSAndMediatorPattern.Application.Common.Behaviors;
using MediatR;

namespace CQRSAndMediatorPattern.Application.Blogs.Commands.UpdateBlog;

public record UpdateBlogCommand(UpdateBlogRequest BlogRequest) : IRequest<ServiceResult>;
