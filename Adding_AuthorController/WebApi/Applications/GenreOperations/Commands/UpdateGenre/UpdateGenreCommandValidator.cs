
using FluentValidation;
using WebApi.Applications.GenreOperations.Commands.UpateGenre;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommands>
    {
         public UpdateGenreCommandValidator()
        {
           
           RuleFor(command => command.Model.Name).MinimumLength(4).When( x => x.Model.Name.Trim() != string.Empty );
           
        }
    }
}