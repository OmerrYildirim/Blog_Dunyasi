using System.Security.Claims;
using DogusProject.Models.Repositories;
using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public class CommentService(ICommentRepository commentRepository,IBlogRepository blogRepository, IHttpContextAccessor contextAccessor) : ICommentService
{
    public AddCommentViewModel CreateViewModel(int id)
    {
        var blog = blogRepository.GetBlogById(id);
        var addCommentViewModel = new AddCommentViewModel();
        addCommentViewModel.BlogId = blog.Id;
        return addCommentViewModel;
    }
    
    public AddCommentViewModel CreateViewModel(AddCommentViewModel addCommentViewModel)
    {
        var blog = blogRepository.GetBlogById(addCommentViewModel.BlogId);
        addCommentViewModel.BlogId = blog.Id;
        return addCommentViewModel;
    }
    
    public void AddComment(AddCommentViewModel addCommentViewModel)
    {
        var comment = new Comment
        {
            CommentText = addCommentViewModel.Content,
            CreatedAt = DateTime.Now,
            BlogId = addCommentViewModel.BlogId,
            UserId = Guid.Parse(contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!)
            
        };

        commentRepository.AddComment(comment);
    }

    public List<CommentViewModel> GetCommentsByBlogId(int blogId)
    {
        var comments = commentRepository.GetCommentsById(blogId);
        return comments.Select(c => new CommentViewModel
        {
            Id = c.Id,
            Content = c.CommentText,
            BlogId = c.BlogId,
            CreatedAt = c.CreatedAt,
        }).ToList();
    }
}