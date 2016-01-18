using BookList.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
