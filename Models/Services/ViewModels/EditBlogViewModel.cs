using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services.ViewModels;

public class EditBlogViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsCustomCategory { get; set; }

    [Display(Name = "Yeni Kategori :")] public string? CustomCategoryName { get; set; }

    [ValidateNever] public SelectList CategoryList { get; set; } = null!;
}