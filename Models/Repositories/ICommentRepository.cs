namespace DogusProject.Models.Repositories;

public interface ICommentRepository
{
    public List<Comment> GetAllComments();
    public List<Comment> GetCommentsById(int id);
    public void AddComment(Comment comment);
    public void DeleteComment(Comment comment);
}