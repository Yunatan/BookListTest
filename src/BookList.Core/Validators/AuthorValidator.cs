using BookList.Core.Models;
using FluentValidation;

namespace BookList.Core.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.FirstName).NotNull().Length(1, 20);
            RuleFor(author => author.LastName).NotNull().Length(1, 20);
        }
    }
}
