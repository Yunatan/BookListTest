using NUnit.Framework;
using BookList.Core.Models;
using System.Linq;
using BookList.Core.Repositories;
using BookList.Core.Repositories.Memory;

namespace BookList.Core.Tests
{
    [TestFixture]
    public class BookRepositoryTest
    {
        private IBookRepository bookRepository;

        [SetUp]
        public void Setup()
        {
            var dataSource = new MemoryDataGenerator().Generate();
            bookRepository = new MemoryBookRepository(dataSource);
        }

        [Test]
        public void CanAddAndGetAll()
        {
            var newBook = new Book
            {
                Title = "Learning Python",
                Pages = 1216,
                PublishDate = 2009,
                Isbn = "0-596-15806-8",
                Publisher = "O'Reilly Media"
            };

            bookRepository.AddBook(newBook);
            var bookList = bookRepository.GetAllBooks();
            var savedBook = bookList.Single(x => x.BookId.Equals(4));

            Assert.AreEqual(bookList.Count, 4);
            Assert.AreSame(newBook, savedBook);
        }

        [Test]
        public void CanUpdateAndGetAll()
        {
            var bookList = bookRepository.GetAllBooks();

            var book = bookList.First();
            book.Pages -= 100;

            bookRepository.UpdateBook(book);
            bookList = bookRepository.GetAllBooks();

            Assert.AreEqual(bookList.Count, 3);
            Assert.AreEqual(bookList.First().Pages, 295);
        }

        [Test]
        public void CanDeleteAndGetAll()
        {
            var bookList = bookRepository.GetAllBooks();

            var book = bookList.First();

            bookRepository.DeleteBook(book.BookId);
            bookList = bookRepository.GetAllBooks();

            Assert.AreEqual(bookList.Count, 2);
            Assert.False(bookList.Contains(book));
        }

        [Test]
        public void CanGetAllSortedByTitleAsc()
        {
            var bookListSorted = bookRepository.GetBooksSorted("Title ASC");

            Assert.AreEqual(bookListSorted[0].BookId, 1);
            Assert.AreEqual(bookListSorted[1].BookId, 2);
            Assert.AreEqual(bookListSorted[2].BookId, 3);
        }

        [Test]
        public void CanGetAllSortedByTitleDesc()
        {
            var bookListSorted = bookRepository.GetBooksSorted("Title DESC");

            Assert.AreEqual(bookListSorted[0].BookId, 3);
            Assert.AreEqual(bookListSorted[1].BookId, 2);
            Assert.AreEqual(bookListSorted[2].BookId, 1);
        }

        [Test]
        public void CanGetAllSortedByPublishDateAsc()
        {
            var bookListSorted = bookRepository.GetBooksSorted("PublishDate ASC");

            Assert.AreEqual(bookListSorted[0].BookId, 1);
            Assert.AreEqual(bookListSorted[1].BookId, 3);
            Assert.AreEqual(bookListSorted[2].BookId, 2);
        }

        [Test]
        public void CanGetAllSortedByPublishDateDesc()
        {
            var bookListSorted = bookRepository.GetBooksSorted("PublishDate DESC");

            Assert.AreEqual(bookListSorted[0].BookId, 2);
            Assert.AreEqual(bookListSorted[1].BookId, 3);
            Assert.AreEqual(bookListSorted[2].BookId, 1);
        }
    }
}
