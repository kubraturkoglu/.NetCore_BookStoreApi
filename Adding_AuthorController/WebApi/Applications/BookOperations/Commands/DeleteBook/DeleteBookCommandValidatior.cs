
using FluentValidation;

namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatior : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidatior()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
} 