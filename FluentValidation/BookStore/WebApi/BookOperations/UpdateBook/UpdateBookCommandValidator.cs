using FluentValidation;

namespace WebApi.BookOperations.UpDateBook
{
    public class UpDateBookCommandValidator : AbstractValidator<UpDateBookCommand>

    {
        public UpDateBookCommandValidator()
        {
           RuleFor(command => command.Model.GenreId).GreaterThan(0);
           
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}