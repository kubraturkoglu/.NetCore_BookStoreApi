
using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail

{
    public class GetBookDetailQueryValidator: AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}