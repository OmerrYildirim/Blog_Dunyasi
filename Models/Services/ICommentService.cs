using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public interface ICommentService
{
    void AddComment(AddCommentViewModel addCommentViewModel);
    List<CommentViewModel> GetCommentsByBlogId(int blogId);
    AddCommentViewModel CreateViewModel(int id);
    AddCommentViewModel CreateViewModel(AddCommentViewModel addCommentViewModel);
}