using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) 
        {

            _validators = validators;

        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationREsults = await Task.WhenAll(

                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var faileur = validationREsults.
                    Where(r => r.Errors.Any()).
                    SelectMany(r => r.Errors).
                    ToList();

                if(faileur.Any())
                {
                    throw new ValidationException(faileur);
                }


            }
            return await next();



        }
    }
}
