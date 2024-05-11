using CQRSAndMediatorPattern.Application.Blogs.Models.Responses;
using CQRSAndMediatorPattern.Domain.Entities;

namespace CQRSAndMediatorPattern.Application.Common.Mappings;

public static class Mapper
{
    public static GetBlogResponse ToViewModel(this Blog blog)
    {
        return new GetBlogResponse()
        {
            Id = blog.Id,
            Name = blog.Name,
            Author = blog.Author,
            Description = blog.Description,
        };
    }
}
