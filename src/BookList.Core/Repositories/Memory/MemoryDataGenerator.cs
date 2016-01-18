using BookList.Core.Models;

namespace BookList.Core.Repositories.Memory
{
    public class MemoryDataGenerator
    {
        public MemoryDataSource Generate()
        {
            var dataSource = new MemoryDataSource();

            dataSource.Books.AddRange(new[]
            {
                new Book
                {
                    BookId = 1,
                    Title = "Design Patterns",
                    Pages = 395,
                    PublishDate = 1994,
                    Isbn = "0-201-63361-2",
                    Publisher = "Addison-Wesley"
                },
                new Book
                {
                    BookId = 2,
                    Title = "The Practice of Programming",
                    Pages = 288,
                    PublishDate = 1999,
                    Isbn = "0-201-61586-X",
                    Publisher = "Addison–Wesley"
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Pragmatic Programmer",
                    Pages = 320,
                    PublishDate = 1998,
                    Isbn = "0-201-61622-X",
                    Publisher = "Addison–Wesley"
                }
            });

            dataSource.Authors.AddRange(new[]
            {
                new Author {AuthorId = 1, BookId = 1, FirstName = "Erich", LastName = "Gamma"},
                new Author {AuthorId = 2, BookId = 1, FirstName = "Richard", LastName = "Helm"},
                new Author {AuthorId = 3, BookId = 1, FirstName = "Ralph", LastName = "Johnson"},
                new Author {AuthorId = 4, BookId = 1, FirstName = "John", LastName = "Vlissides"},
                new Author {AuthorId = 5, BookId = 2, FirstName = "Brian", LastName = "Kernighan"},
                new Author {AuthorId = 6, BookId = 2, FirstName = "Rob", LastName = "Pike"},
                new Author {AuthorId = 7, BookId = 3, FirstName = "Andrew", LastName = "Hunt"},
                new Author {AuthorId = 8, BookId = 3, FirstName = "David", LastName = "Thomas"}
            });

            return dataSource;
        }
    }
}
