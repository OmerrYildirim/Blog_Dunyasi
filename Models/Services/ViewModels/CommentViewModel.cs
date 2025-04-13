using System.ComponentModel.DataAnnotations;

namespace DogusProject.Models.Services.ViewModels;

public class CommentViewModel
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    [Display(Name = "Bir yorum yazın")]
    [Required(ErrorMessage = "Yorum boş olamaz.")]
    public string Content { get; set; }=null!;
    public string UserName { get; set; } = null!;
    public int BlogId { get; set; }
    public DateTime CreatedAt { get; set; }
    
}