
using System;
using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
            
        }
    }
}