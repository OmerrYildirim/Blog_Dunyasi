using DogusProject.Models.Repositories.Entities;

namespace DogusProject.Models.Repositories;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; } 
    public AppUser Author { get; set; } = null!; 
    public int CategoryId { get; set; } 
    public Category Category { get; set; } = null!; 
    public string? ImageUrl { get; set; }
    public int CommentId { get; set; }
    public List<Comment>? Comments { get; set; } = null!;
}
