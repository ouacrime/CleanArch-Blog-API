using CleanArchi.Application.Common.Mappings;
using CleanArchi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm :IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }

    
}
