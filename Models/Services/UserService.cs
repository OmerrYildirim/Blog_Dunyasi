using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DogusProject.Models.Services;
public class UserService(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    SignInManager<AppUser> signInManager)
    : IUserService
{

    public bool CreateUser(CreateUserViewModel model)
    {
        var user = new AppUser
        {
            UserName = model.UserName,
            Email = model.Email,
            
        };
        var result = userManager.CreateAsync(user, model.Password).Result;

        return result.Succeeded;
    }

    public bool Login(LoginViewModel model)
    {
        var hasUser = userManager.FindByEmailAsync(model.Email).Result;

        if (hasUser == null) return false;


        var result = signInManager.PasswordSignInAsync(hasUser.UserName!, model.Password, true, false).Result;
        return result.Succeeded;
    }

    public void SignOut()
    {
        signInManager.SignOutAsync();
    }
}