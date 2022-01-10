using System;
using FluentValidation;
using WebApi.Applications.GenreOperations.Commands.CreateAuthor;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {   
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
         
            
        }


    }
}
