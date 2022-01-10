
using FluentValidation;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail

{
    public class GetBookDetailQueryValidator: AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}