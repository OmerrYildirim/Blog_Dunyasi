using DogusProject.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DogusProject.Models;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
   public List<Category> GetAllCategories()
   {
      return context.Categories.ToList();
   }
   
   public void AddCategory(Category category)
   {
      context.Categories.Add(category);
      context.SaveChanges();
   }

   public Category GetCategoryById(int id)
   {
      var category = context.Categories
         .Include(c => c.Blogs)
         .FirstOrDefault(c => c.Id == id);
      
      return category;  
   }
   
   public void DeleteEmptyCategories(Category category)
   {
      context.Categories.Remove(category);
      context.SaveChanges();
   }
}