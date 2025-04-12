using System.Security.Claims;
using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services;

public class BlogService(
    IBlogRepository blogRepository,
    ICategoryRepository categoryRepository,
    IHttpContextAccessor contextAccessor) : IBlogService
{
    public List<BlogViewModel> GetAllBlogs()
    {
        var blogs = blogRepository.GetAllBlogs();
        var blogViewModels = new List<BlogViewModel>();

        foreach (var blog in blogs)
        {
            var blogViewModel = new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                AuthorName = blog.Author.UserName,
                CategoryName = blog.Category.Name,
                ImageUrl = blog.ImageUrl,
            };
            blogViewModels.Add(blogViewModel);
        }

        return blogViewModels;
    }

    public AddBlogViewModel CreateViewModel()
    {
        var categories = categoryRepository.GetAllCategories();
        var addBlogViewModel = new AddBlogViewModel();
        addBlogViewModel.CategoryList = new SelectList(categories, "Id", "Name");
        return addBlogViewModel;
    }

    public AddBlogViewModel CreateViewModel(AddBlogViewModel addBlogViewModel)
    {
        var categories = categoryRepository.GetAllCategories();
        addBlogViewModel.CategoryList = new SelectList(categories, "Id", "Name", addBlogViewModel.CategoryId);
        return addBlogViewModel;
    }

    public void AddCategoryForAdd(AddBlogViewModel addBlogViewModel)
    {
        if (addBlogViewModel.IsCustomCategory && 
            !string.IsNullOrWhiteSpace(addBlogViewModel.CustomCategoryName))
        {
            var newCategory = new Category
            {
                Name = addBlogViewModel.CustomCategoryName
            };
            categoryRepository.AddCategory(newCategory); 
            addBlogViewModel.CategoryId = newCategory.Id;

        }
    }
    public void AddCategoryForEdit(EditBlogViewModel editBlogViewModel)
    {
        if (editBlogViewModel.IsCustomCategory && 
            !string.IsNullOrWhiteSpace(editBlogViewModel.CustomCategoryName))
        {
            var newCategory = new Category
            {
                Name = editBlogViewModel.CustomCategoryName
            };
        
            categoryRepository.AddCategory(newCategory); 
            editBlogViewModel.CategoryId = newCategory.Id;
        }
    }

    public void AddBlog(AddBlogViewModel addBlogViewModel)
    {
        AddCategoryForAdd(addBlogViewModel);
        
        var blog = new Blog
        {
            Title = addBlogViewModel.Title!,
            Content = addBlogViewModel.Content,
            CreatedAt = DateTime.Now,
            CategoryId = addBlogViewModel.CategoryId,
            ImageUrl = addBlogViewModel.ImageUrl,
            AuthorId = Guid.Parse(contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!),
        };
        
        blogRepository.AddBlog(blog);
    }
    
    public Blog GetBlogById(int id)
    {
        return blogRepository.GetBlogById(id);
    }
    
    public EditBlogViewModel CreateEditViewModel(int id)
    {
        var blog = blogRepository.GetBlogById(id);
        var categories = categoryRepository.GetAllCategories();
        var editBlogViewModel = new EditBlogViewModel
        {
            Id = blog.Id,
            Title = blog.Title,
            Content = blog.Content,
            CategoryId = blog.CategoryId,
            CreatedAt = DateTime.Now,
            ImageUrl = blog.ImageUrl,
            CategoryList = new SelectList(categories, "Id", "Name", blog.CategoryId),
        };
        return editBlogViewModel;
    }
    
    public void UpdateBlog(EditBlogViewModel editBlogViewModel)
    {
        var existingBlog = blogRepository.GetBlogById(editBlogViewModel.Id);
        if (existingBlog == null) return;

        var currentUserId = Guid.Parse(contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        if (existingBlog.AuthorId != currentUserId) return;
        
        AddCategoryForEdit(editBlogViewModel);

        existingBlog.Title = editBlogViewModel.Title;
        existingBlog.Content = editBlogViewModel.Content;
        existingBlog.CategoryId = editBlogViewModel.CategoryId;
        existingBlog.CreatedAt = DateTime.Now;
        existingBlog.ImageUrl = editBlogViewModel.ImageUrl;

        blogRepository.UpdateBlog(existingBlog);
    }
    
    public void DeleteBlog(int id)
    {
        var blog = blogRepository.GetBlogById(id);
        if (blog == null) return;

        var currentUserId = Guid.Parse(contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        if (blog.AuthorId != currentUserId) return; 
        blogRepository.DeleteBlog(blog);
        
        int categoryId = blog.CategoryId;
        DeleteEmptyCategories(categoryId);
        
    }
    
    public BlogPageViewModel CreateBlogPageViewModel(int categoryId)
    {
        
        var categories = GetAllCategories()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

        var blogs = categoryId > 0
            ? GetBlogsByCategory(categoryId)
            : GetAllBlogs();

        var blogPageViewModel = new BlogPageViewModel
        {
            BlogList = blogs.Select(blog => new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                AuthorName = blog.AuthorName,
                CategoryName = blog.CategoryName,
                ImageUrl = blog.ImageUrl
            }).ToList(),
            CategoryList = categories,
            CategoryId = categoryId
        };

        return blogPageViewModel;

    }
    
    public List<BlogViewModel> GetBlogsByCategory(int categoryId)
    {
        var blogs = blogRepository.GetBlogByCategories(categoryId);
        var blogViewModels = new List<BlogViewModel>();
        var categories = categoryRepository.GetAllCategories();

        foreach (var blog in blogs)
        {
            var blogViewModel = new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                AuthorName = blog.Author.UserName,
                CategoryName = blog.Category.Name,
                ImageUrl = blog.ImageUrl,
                CategoryId = blog.CategoryId,
                CategoryList = new SelectList(categories, "Id", "Name", blog.CategoryId),
            };
            blogViewModels.Add(blogViewModel);
        }

        return blogViewModels;
    }
    public List<Category> GetAllCategories()
    {
        return categoryRepository.GetAllCategories();
    }
    
    public BlogViewModel GetDetails(int id)
    {
        var blog = blogRepository.GetBlogById(id);
        if (blog == null) return null;

        var blogViewModel = new BlogViewModel
        {
            Id = blog.Id,
            Title = blog.Title,
            Content = blog.Content,
            CreatedAt = blog.CreatedAt,
            AuthorName = blog.Author.UserName,
            CategoryName = blog.Category.Name,
            ImageUrl = blog.ImageUrl
        };

        return blogViewModel;
    }
    public void DeleteEmptyCategories(int categoryId)
    {
        
        bool hasOtherBlogs = blogRepository.HasOtherBlogsInCategory(categoryId);

        if (!hasOtherBlogs)
        {
            var category = categoryRepository.GetCategoryById(categoryId);
            if (category != null)
            {
                categoryRepository.DeleteEmptyCategories(category);
            }
        }
    }
    
    
    
    

}