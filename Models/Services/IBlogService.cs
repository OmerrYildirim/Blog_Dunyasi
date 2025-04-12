using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public interface IBlogService
{
    public List<BlogViewModel> GetAllBlogs();
    public AddBlogViewModel CreateViewModel();
    public AddBlogViewModel CreateViewModel(AddBlogViewModel addBlogViewModel);
    public void AddBlog(AddBlogViewModel addBlogViewModel);
    public Blog GetBlogById(int id);
    public EditBlogViewModel CreateEditViewModel(int id);
    public void UpdateBlog(EditBlogViewModel editBlogViewModel);
    public void DeleteBlog(int id);
    public List<BlogViewModel> GetBlogsByCategory(int categoryId);
    public List<Category> GetAllCategories();
    public BlogPageViewModel CreateBlogPageViewModel(int categoryId);
    public void AddCategoryForAdd(AddBlogViewModel addBlogViewModel);
    public void AddCategoryForEdit(EditBlogViewModel editBlogViewModel);
    public BlogViewModel GetDetails(int id);
    

}