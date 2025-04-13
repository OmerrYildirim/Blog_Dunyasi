using DogusProject.Models.Repositories;
using DogusProject.Models.Services.ViewModels;

namespace DogusProject.Models.Services;

public class CategoryService(ICategoryRepository categoryRepository, IBlogRepository blogRepository): ICategoryService
{

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