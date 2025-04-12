namespace DogusProject.Models.Repositories;

public interface ICategoryRepository
{
    public List<Category> GetAllCategories();
    public void AddCategory(Category category);
    public Category GetCategoryById(int id);
    public void DeleteEmptyCategories(Category category);

}