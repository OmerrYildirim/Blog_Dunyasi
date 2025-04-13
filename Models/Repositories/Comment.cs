using DogusProject.Models.Repositories.Entities;

namespace DogusProject.Models.Repositories;

public class Comment
{
    public int Id { get; set; }
    public Guid UserId { get; set; } 
    public AppUser User { get; set; } = null!; 
    public string CommentText { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
    
    
}