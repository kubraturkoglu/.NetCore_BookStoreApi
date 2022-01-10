
using FluentValidation;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommands>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}