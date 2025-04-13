using Microsoft.EntityFrameworkCore;

namespace DogusProject.Models.Repositories;

public class BlogRepository(AppDbContext context) : IBlogRepository
{
    public List<Blog> GetAllBlogs()
    {
        return context.Blogs.Include(x => x.Category).Include(x => x.Author).ToList();
    }

    public void AddBlog(Blog blog)
    {
        context.Blogs.Add(blog);
        context.SaveChanges();
    }

    public Blog GetBlogById(int id)
    {
        var blog = context.Blogs
            .Include(x => x.Category)
            .Include(x => x.Author)
            .FirstOrDefault(x => x.Id == id);

        if (blog == null)
        {
            // Log için
            var allBlogIds = context.Blogs.Select(b => b.Id).ToList();
            Console.WriteLine($"Aranan ID: {id}");
            Console.WriteLine($"Mevcut ID'ler: {string.Join(", ", allBlogIds)}");
        }

        return blog;
    }

    public void UpdateBlog(Blog blog)
    {
        context.Blogs.Update(blog);
        context.SaveChanges();
    }

    public void DeleteBlog(Blog blog)
    {
        context.Blogs.Remove(blog);
        context.SaveChanges();
    }

    public List<Blog> GetBlogByCategories(int id)
    {
        var blogs = context.Blogs.Include(x => x.Category).Include(x => x.Author).Where(x => x.CategoryId == id)
            .ToList();
        return blogs;
    }

    public bool HasOtherBlogsInCategory(int categoryId)
    {
       return context.Blogs.Any(b => b.CategoryId == categoryId);
    }
        
    public List<Blog> GetBlogsByAuthorId(Guid authorId)
    {
        return context.Blogs
            .Include(x => x.Category)
            .Include(x => x.Author)
            .Where(b => b.AuthorId == authorId)
            .OrderByDescending(b => b.CreatedAt)
            .ToList();
    }
}