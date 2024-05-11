using System.ComponentModel.DataAnnotations;

namespace CQRSAndMediatorPattern.Domain.Entities;

public class Blog
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}
