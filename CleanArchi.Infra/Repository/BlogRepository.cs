using CleanArchi.Domain.Entity;
using CleanArchi.Domain.Repository;
using CleanArchi.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;

        }

        public async Task<int> DeleteAsync(int id)
        {
            var blog = await _blogDbContext.Blogs.FirstOrDefaultAsync(model => model.Id == id);

            if (blog != null)
            {
                _blogDbContext.Blogs.Remove(blog);
                return await _blogDbContext.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the blog with the specified id is not found
                // For example, you can throw an exception or return a specific value
                // Throw an exception to indicate that the entity was not found
                throw new Exception($"Blog with id {id} not found.");
                //or
                // Alternatively, return a specific value, such as 0, to indicate failure
                // return 0;
            }
            //return await _blogDbContext.Blogs
            //    .Where(model => model.Id == id)
            //    .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            //return await _blogDbContext.Blogs
            //    .Where(model => model.Id == id)
            //    .ExecuteUpdateAsync(setters => setters
            //    .SetProperty(m => m.Id, blog.Id)
            //    .SetProperty(m => m.Name, blog.Name)
            //    .SetProperty(m => m.Description, blog.Description)
            //    .SetProperty(m => m.Author, blog.Author));

            var existingBlog = await _blogDbContext.Blogs.FirstOrDefaultAsync(model => model.Id == id);

            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                existingBlog.Description = blog.Description;
                existingBlog.Author = blog.Author;

                // Optionally, you can update other properties as needed

                return await _blogDbContext.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the blog with the specified id is not found
                // For example, throw an exception or return a specific value

                // Throw an exception to indicate that the entity was not found
                throw new Exception($"Blog with id {id} not found.");

                // Alternatively, return a specific value, such as 0, to indicate failure
                // return 0;
            };
        }
    
    }
}
