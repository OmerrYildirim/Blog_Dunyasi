using System.ComponentModel.DataAnnotations;

namespace DogusProject.Models.Services.ViewModels;


public class CreateUserViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı boş olamaz.")]
    [Display (Name = "Kullanıcı Adı :")]
    public string UserName { get; set; } = null!;
    
    [Required(ErrorMessage = "Email boş olamaz.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    [Display (Name = "Email :")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Şifre boş olamaz.")]
    [Display (Name = "Şifre :")]
    public string Password { get; set; } = null!;
}