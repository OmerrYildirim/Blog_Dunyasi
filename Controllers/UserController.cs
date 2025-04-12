using DogusProject.Models.Services;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogusProject.Controllers;

public class UserController (IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult CreateUser( )
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var result = userService.CreateUser(model);
        if (result) return RedirectToAction("Login", "User");

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var result = userService.Login(model);
        if (result) return RedirectToAction("Index", "Blog");
        ModelState.AddModelError("", "Email veya şifre yanlış");

        return View(model);
    }

    [HttpGet]
    public IActionResult SignOut()
    {
        userService.SignOut();
        return RedirectToAction("Index", "Blog");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
    
}