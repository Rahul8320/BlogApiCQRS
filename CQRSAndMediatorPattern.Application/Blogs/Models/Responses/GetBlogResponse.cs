namespace CQRSAndMediatorPattern.Application.Blogs.Models.Responses;

public class GetBlogResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
