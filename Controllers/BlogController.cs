using System.Security.Claims;
using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Controllers;

[Authorize]
public class BlogController(IBlogService blogService) : Controller
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index(int? categoryId)
    {
        var blogViewModels = blogService.CreateBlogPageViewModel(categoryId ?? 0);

        return View(blogViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var addBlogViewModel = blogService.CreateViewModel();
        return View(addBlogViewModel);
    }

    [HttpPost]
    public IActionResult Create(AddBlogViewModel addBlogViewModel)
    {
        if (!ModelState.IsValid) return View(blogService.CreateViewModel(addBlogViewModel));
        blogService.AddBlog(addBlogViewModel);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var blog = blogService.GetBlogById(id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (blog.AuthorId.ToString() != userId)
        {
            TempData["Reason"] = "UnauthorizedAction";
            return RedirectToAction("Index");
        }

        var editBlogViewModel = blogService.CreateEditViewModel(id);
        return View(editBlogViewModel);
    }

    [HttpPost]
    public IActionResult Edit(EditBlogViewModel editBlogViewModel)
    {
        var blog = blogService.GetBlogById(editBlogViewModel.Id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (blog.AuthorId.ToString() != userId)
        {
            TempData["Reason"] = "UnauthorizedAction";
            return RedirectToAction("Index");
        }

        if (!ModelState.IsValid)
            return View(blogService.CreateEditViewModel(editBlogViewModel.Id));

        blogService.UpdateBlog(editBlogViewModel);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var blog = blogService.GetBlogById(id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (blog.AuthorId.ToString() != userId)
        {
            TempData["Reason"] = "UnauthorizedAction";
            return RedirectToAction("Index");
        }

        blogService.DeleteBlog(id);
        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Details(int id)
    {
        var blog = blogService.GetDetails(id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }
}