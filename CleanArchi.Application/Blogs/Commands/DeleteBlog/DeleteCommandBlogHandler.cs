using CleanArchi.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteCommandBlogHandler : IRequestHandler<DeleteCommandBlog, int>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteCommandBlogHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(DeleteCommandBlog request, CancellationToken cancellationToken)
        {
           return  await _blogRepository.DeleteAsync(request.Id);
        }
    }

}
