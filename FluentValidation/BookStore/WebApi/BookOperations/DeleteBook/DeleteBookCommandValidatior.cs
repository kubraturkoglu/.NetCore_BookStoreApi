
using FluentValidation;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidatior : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidatior()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}