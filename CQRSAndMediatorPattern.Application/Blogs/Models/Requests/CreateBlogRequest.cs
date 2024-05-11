﻿using System.ComponentModel.DataAnnotations;

namespace CQRSAndMediatorPattern.Application.Blogs.Models.Requests;

public class CreateBlogRequest
{
    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(50)]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Author { get; set; } = string.Empty;
}
