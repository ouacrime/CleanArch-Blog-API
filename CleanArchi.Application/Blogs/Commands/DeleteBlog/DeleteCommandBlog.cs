using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteCommandBlog : IRequest<int>
    {
       public int Id { get; set; }


    }
}
