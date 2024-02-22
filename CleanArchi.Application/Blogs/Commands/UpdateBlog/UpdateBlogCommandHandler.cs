using CleanArchi.Domain.Entity;
using CleanArchi.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;


        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var UpdateBlogEntity = new Blog()
            {
                Id = request.Id,
                Author = request.Author,    
                Description = request.Description,
                Name = request.Name,
            };

            return await _blogRepository.UpdateAsync(request.Id, UpdateBlogEntity);
        }
    }
}
