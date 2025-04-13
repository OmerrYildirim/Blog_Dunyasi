using DogusProject.Models.Services;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogusProject.Controllers;

[Authorize]
public class CommentController(ICommentService commentService) : Controller
{
    
    [HttpGet]
    public IActionResult AddComment(int blogId)
    {
        var addCommentViewModel = commentService.CreateViewModel(blogId);
        return RedirectToAction("Details","Blog" , addCommentViewModel);
    }
    [HttpPost]
    public IActionResult AddComment(AddCommentViewModel addCommentViewModel)
    {
        if (!ModelState.IsValid) 
            return RedirectToAction("Details","Blog",commentService.CreateViewModel(addCommentViewModel));
        
        commentService.AddComment(addCommentViewModel);
        return RedirectToAction("Index", "Blog");
    }
    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetCommentsByBlogId(int blogId)
    {
        var comments = commentService.GetCommentsByBlogId(blogId);
        return PartialView("~/Views/Shared/PartialViews/_commentList.cshtml", comments);
    }
}