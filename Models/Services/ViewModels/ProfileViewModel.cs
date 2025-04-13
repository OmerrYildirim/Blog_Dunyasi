namespace DogusProject.Models.Services.ViewModels;

public class ProfileViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<BlogViewModel> Blogs { get; set; }
}