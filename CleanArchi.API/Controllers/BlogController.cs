using CleanArchi.Application.Blogs.Commands.CreateBlog;
using CleanArchi.Application.Blogs.Commands.DeleteBlog;
using CleanArchi.Application.Blogs.Commands.UpdateBlog;
using CleanArchi.Application.Blogs.Queries.GetBlogs;
using CleanArchi.Application.Blogs.Queries.GetBlogsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());

            return Ok(blogs);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery()
            {
                BlogId = id
            }); 
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)

        {
            var createdBlog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateBlogCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCommandBlog { Id = id});

            if (result == 0)
            {
                return BadRequest();
            }


            return NoContent() ;
        }


    }
}
