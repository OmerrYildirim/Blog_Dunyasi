using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services.ViewModels;

public class BlogViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string AuthorName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public SelectList CategoryList { get; set; } = null!;
    public List<CommentViewModel> Comments { get; set; } = null!;
   
}