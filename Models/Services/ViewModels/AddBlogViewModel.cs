using System.ComponentModel.DataAnnotations;
using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services.ViewModels;

public class AddBlogViewModel : IValidatableObject
{
    [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
    [Display(Name = "Başlık :")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "İçerik alanı boş bırakılamaz.")]
    [Display(Name = "İçerik :")]
    public string Content { get; set; } = null!;

    [Required(ErrorMessage = "Kategori alanı boş bırakılamaz.")]
    [Display(Name = "Lütfen bir kategori seçiniz :")]

    public int CategoryId { get; set; }

    [Display(Name = "Resim yüklemek isterseniz geçerli bir URL giriniz :")]
    public string? ImageUrl { get; set; }

    public bool IsCustomCategory { get; set; }
    [Display(Name = "Yeni Kategori :")] public string? CustomCategoryName { get; set; }
    
    [ValidateNever] public SelectList CategoryList { get; set; } = null!;
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var dbContext = validationContext.GetService(typeof(ICategoryRepository)) as ICategoryRepository;

        if (string.IsNullOrEmpty(CustomCategoryName)) yield break;
        
        var existingCategory = dbContext.GetAllCategories()
            .FirstOrDefault(c => c.Name == CustomCategoryName);

        if (existingCategory != null)
        {
            yield return new ValidationResult(
                "Girdiğiniz kategori zaten var.",
                new[] { nameof(CustomCategoryName) }
            );
        }
    }
}