namespace DogusProject.Models.Repositories;

public interface IBlogRepository 
{
    
    void AddBlog(Blog blog);
    public List<Blog> GetAllBlogs();
    public Blog GetBlogById(int id);
    public void UpdateBlog(Blog blog);
    public void DeleteBlog(Blog blog);
    public List<Blog> GetBlogByCategories(int id);
    public bool HasOtherBlogsInCategory(int categoryId);
    public List<Blog> GetBlogsByAuthorId(Guid authorId);

}