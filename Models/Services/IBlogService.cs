using DogusProject.Models.Repositories;
using DogusProject.Models.Repositories.Entities;
using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public interface IBlogService
{
   
    public AddBlogViewModel CreateViewModel();
    public AddBlogViewModel CreateViewModel(AddBlogViewModel addBlogViewModel);
    public void AddBlog(AddBlogViewModel addBlogViewModel);
    public Blog GetBlogById(int id);
    public EditBlogViewModel CreateEditViewModel(int id);
    public void UpdateBlog(EditBlogViewModel editBlogViewModel);
    public void DeleteBlog(int id);
    public BlogPageViewModel CreateBlogPageViewModel(int categoryId);
    public BlogViewModel GetDetails(int id);
    

}