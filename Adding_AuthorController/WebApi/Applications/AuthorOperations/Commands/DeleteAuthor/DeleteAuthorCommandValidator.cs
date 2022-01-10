using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatior : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidatior()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
} 