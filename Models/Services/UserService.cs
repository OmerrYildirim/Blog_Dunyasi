using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DogusProject.Models.Services;
public class UserService(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IBlogRepository blogRepository,
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
    public List<BlogViewModel> GetUserBlogs(string userId)
    {
        if (!Guid.TryParse(userId, out Guid authorId))
        {
            return new List<BlogViewModel>();
        }
        
        var blogs = blogRepository.GetBlogsByAuthorId(authorId);
        
        return blogs.Select(blog => new BlogViewModel
        {
            Id = blog.Id,
            Title = blog.Title,
            Content = blog.Content,
            CreatedAt = blog.CreatedAt,
            AuthorName = blog.Author.UserName,
            CategoryName = blog.Category.Name,
            ImageUrl = blog.ImageUrl
        }).ToList();
    }
    public ProfileViewModel CreateProfileViewModel(string userId)
    {
        var user = userManager.FindByIdAsync(userId).Result;
        if (user == null) return null;

        var blogs = GetUserBlogs(userId);

        return new ProfileViewModel
        {
            UserName = user.UserName,
            Email = user.Email,
            Blogs = blogs
        };
    }
}