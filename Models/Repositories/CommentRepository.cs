using Microsoft.EntityFrameworkCore;

namespace DogusProject.Models.Repositories;

public class CommentRepository(AppDbContext context) :ICommentRepository
{

    public List<Comment> GetCommentsById(int id)
    {
        return context.Comments
            .Include(c => c.User)
            .Where(c => c.BlogId == id)
            .ToList();
    }
    public void AddComment(Comment comment)
    {
        context.Comments.Add(comment);
        context.SaveChanges();
    }
    public void DeleteComment(Comment comment)
    {
        context.Comments.Remove(comment);
        context.SaveChanges();
    }
    
}