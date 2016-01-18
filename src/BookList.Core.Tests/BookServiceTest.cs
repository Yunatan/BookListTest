using NUnit.Framework;
using System;
using BookList.Core.Services;
using BookList.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookList.Core.Tests
{
    [TestFixture]
    public class BookServiceTest
    {
        private IBookRepository bookService;

        [SetUp]
        public void Setup()
        {
            var testBooks = new List<Book>
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

            bookService = new MemoryBookRepository(testBooks);
        }

        [Test]
        public void CanSaveAndGetAll()
        {
            var newBook = new Book
            {
                Title = "Learning Python",
                Authors = new List<Author> {
                        new Author { FirstName= "Mark", LastName = "Lutz" }
                    },
                Pages = 1216,
                PublishDate = 2009,
                Isbn = "0-596-15806-8",
                Publisher = "O'Reilly Media"
            };

            bookService.Save(newBook);
            var bookList = bookService.GetAll();

            Assert.AreEqual(bookList.Count, 4);
            Assert.AreSame(bookList.Last(), newBook);
        }

        [Test]
        public void CanUpdateAndGetAll()
        {
            var bookList = bookService.GetAll();

            var book = bookList.First();
            book.Pages -= 100;

            bookService.Update(book);
            bookList = bookService.GetAll();

            Assert.AreEqual(bookList.Count, 3);
            Assert.AreEqual(bookList.First().Pages, 295);
        }

        [Test]
        public void CanDeleteAndGetAll()
        {
            var bookList = bookService.GetAll();

            var book = bookList.First();

            bookService.Delete(book.BookId);
            bookList = bookService.GetAll();

            Assert.AreEqual(bookList.Count, 2);
            Assert.False(bookList.Contains(book));
        }

        [Test]
        public void CanGetAllSorted()
        {
        }
    }
}
