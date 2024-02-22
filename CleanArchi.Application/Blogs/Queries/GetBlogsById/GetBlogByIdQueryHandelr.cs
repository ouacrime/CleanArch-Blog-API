using AutoMapper;
using CleanArchi.Application.Blogs.Queries.GetBlogs;
using CleanArchi.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Queries.GetBlogsById

{
    public class GetBlogByIdQueryHandelr : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;

        private readonly IMapper _mapper;


        public GetBlogByIdQueryHandelr(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);
            return  _mapper.Map<BlogVm>(blog);
        }
    }
}
