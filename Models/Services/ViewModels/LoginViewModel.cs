using System.ComponentModel.DataAnnotations;

namespace DogusProject.Models.Services.ViewModels;


public class LoginViewModel
{
    [Required(ErrorMessage = "Email boş olamaz.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    [Display(Name = "E-posta :")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Şifre boş olamaz.")]
    [Display(Name = "Şifre :")]
    public string Password { get; set; } = null!;
}