using DogusProject.Models.Repositories;
using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public interface ICategoryService
{
   
    public void AddCategoryForAdd(AddBlogViewModel addBlogViewModel);
    public void AddCategoryForEdit(EditBlogViewModel editBlogViewModel);
    public void DeleteEmptyCategories(int categoryId);
}