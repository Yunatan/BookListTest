using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookList.Core.Models;

namespace BookList.Core.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title).NotNull().Length(1, 30);
            RuleFor(book => book.Pages).InclusiveBetween(1, 10000);
            RuleFor(book => book.Publisher).Length(1, 30);
            RuleFor(book => book.PublishDate).GreaterThanOrEqualTo(1800);
            RuleFor(book => book.Isbn).Must(HaveValidIsbn);
        }

        private bool HaveValidIsbn(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                return false;
            }

            isbn = Regex.Replace(isbn, @"[^\dX]", string.Empty);
            if (isbn.Length != 10)
            {
                return false;
            }

            var nums = isbn.Select(x => x.ToString()).ToArray();
            if (nums[9].ToUpper().Equals("X"))
            {
                nums[9] = "10";
            }

            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += ((10 - i) * int.Parse(nums[i]));
            }

            return ((sum % 11) == 0);
        }
    }
}
