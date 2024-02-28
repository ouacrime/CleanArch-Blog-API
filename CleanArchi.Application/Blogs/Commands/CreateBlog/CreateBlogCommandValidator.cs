using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator() 
        {
            RuleFor(V => V.Name)
                .NotEmpty().WithMessage("Name is require .")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

            RuleFor(V => V.Description)
                           .NotEmpty().WithMessage("Description is require .");

            RuleFor(V => V.Author)
               .NotEmpty().WithMessage("Author is require .")
               .MaximumLength(20).WithMessage("Author must not exceed 20 characters");

        }

    }
}
