using System.ComponentModel.DataAnnotations;
using DogusProject.Models.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services.ViewModels;

public class EditBlogViewModel
{
    public int Id { get; set; }
    [Validations.Length(5, 20, ErrorMessage = "Başlık 5 ile 20 karakter arasında olmalıdır.")]
    [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
    [Display(Name = "Başlık :")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "İçerik alanı boş bırakılamaz.")]
    [Display(Name = "İçerik :")]
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
    [Display(Name = "Resim URL:")]
    public string? ImageUrl { get; set; }
    public bool IsCustomCategory { get; set; }

    [UniqueCategory]
    [CustomCategoryRequired]
    [Display(Name = "Yeni Kategori :")]
    [Validations.Length(3, 20, ErrorMessage = "Kategori adı 3 ile 20 karakter arasında olmalıdır.")]
    public string? CustomCategoryName { get; set; }

    [ValidateNever] public SelectList CategoryList { get; set; } = null!;
}