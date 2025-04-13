namespace DogusProject.Models.Services.ViewModels;

public class AddCommentViewModel
{
    public int BlogId { get; set; }
    public string Content { get; set; }=null!;
    
}