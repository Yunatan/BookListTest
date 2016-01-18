using BookList.Core.Validators;
using FluentValidation.Attributes;

namespace BookList.Core.Models
{
    [Validator(typeof(AuthorValidator))]
    public class Author
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
