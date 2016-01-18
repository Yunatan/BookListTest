using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList.Core.Models;

namespace BookList.Core.Services
{
    public class MemoryBookRepository : IBookRepository
    {
        static List<Book> bookList = new List<Book>
            {
                new Book
                {
                    BookId = new Guid("05e1dd5a-b190-4662-b92c-907b375664b4"),
                    Title = "Design Patterns",
                    Authors = new List<Author> {
                        new Author { FirstName= "Erich", LastName = "Gamma" },
                        new Author { FirstName= "Richard", LastName = "Helm" },
                        new Author { FirstName= "Ralph", LastName = "Johnson" },
                        new Author { FirstName= "John", LastName = "Vlissides" }
                    },
                    Pages = 395,
                    PublishDate = 1994,
                    Isbn = "0-201-63361-2",
                    Publisher = "Addison-Wesley"
                },
                new Book
                {
                    BookId = new Guid("a55e3b99-890d-490e-8b3b-5d1b205b486a"),
                    Title = "The Practice of Programming",
                    Authors = new List<Author> {
                        new Author { FirstName= "Brian", LastName = "Kernighan" },
                        new Author { FirstName= "Rob", LastName = "Pike" }
                    },
                    Pages = 288,
                    PublishDate = 1999,
                    Isbn = "0-201-61586-X",
                    Publisher = "Addison–Wesley"
                },
                new Book
                {
                    BookId = new Guid("ab5cb085-1f9f-476d-b77c-c5ed238da68f"),
                    Title = "The Pragmatic Programmer",
                    Authors = new List<Author> {
                        new Author { FirstName= "Andrew", LastName = "Hunt" },
                        new Author { FirstName= "David", LastName = "Thomas" }
                    },
                    Pages = 320,
                    PublishDate = 1999,
                    Isbn = "0-201-61622-X",
                    Publisher = "Addison–Wesley"
                }
        };

        public MemoryBookRepository(List<Book> initialData)
        {
            bookList = initialData;
        }

        public MemoryBookRepository()
        {
        }

        public List<Book> GetAll()
        {
            return bookList;
        }

        public Book Save(Book newBook)
        {
            newBook.BookId = new Guid();
            bookList.Add(newBook);
            return newBook;
        }

        public void Update(Book newBook)
        {
            var index = bookList.FindIndex(book => book.BookId.Equals(newBook.BookId));
            bookList.RemoveAll(book => book.BookId.Equals(newBook.BookId));
            bookList.Insert(index, newBook);
        }

        public void Delete(Guid bookId)
        {
            bookList.RemoveAll(book => book.BookId.Equals(bookId));
        }
    }
}
