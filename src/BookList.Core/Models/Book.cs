using System.Drawing;
using BookList.Core.Validators;
using FluentValidation.Attributes;

namespace BookList.Core.Models
{
    [Validator(typeof(BookValidator))]
    public class Book
    {
        public int BookId { get; set; }

        public Image Image { get; set; }

        public string Isbn { get; set; }

        public int Pages { get; set; }

        public int PublishDate { get; set; }

        public string Publisher { get; set; }

        public string Title { get; set; }
    }
}
