using Microsoft.AspNetCore.Identity;

namespace DogusProject.Models.Repositories.Entities;


public class AppUser : IdentityUser<Guid>
{
    public List<Blog>? Blogs { get; set; } 
}