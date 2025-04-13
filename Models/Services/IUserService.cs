using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;


public interface IUserService
{
    bool CreateUser(CreateUserViewModel model);
    bool Login(LoginViewModel model);
    void SignOut();
    public List<BlogViewModel> GetUserBlogs(string userId);
    public ProfileViewModel CreateProfileViewModel(string userId);
}