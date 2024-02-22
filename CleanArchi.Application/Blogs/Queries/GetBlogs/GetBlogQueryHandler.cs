using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchi.Domain.Repository;
using MediatR;
using MediatR.Pipeline;

namespace CleanArchi.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogQueryHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {

            var blogs = await _blogRepository.GetAllBlogAsync();
            //var blogList = blogs.Select(x => new BlogVm
            //{
            //    Author = x.Author,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Id = x.Id
            //}).ToList();

            var blogList = _mapper.Map<List<BlogVm>>(blogs);

            return blogList;
        }
    }

}
