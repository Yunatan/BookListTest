using System.Collections.Generic;
using System.Linq;
using BookList.Core.Models;
using BookList.Core.Extensions;

namespace BookList.Core.Repositories.Memory
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly MemoryDataSource dataSource;

        public MemoryBookRepository(MemoryDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public List<Book> GetAllBooks()
        {
            return dataSource.Books.OrderBy(s => s.Title).ToList();
        }

        public List<Book> GetBooks(string sortString)
        {
            var query = dataSource.Books.AsQueryable().OrderByField(sortString);

            return query.ToList(); 
        }

        public Book AddBook(Book book)
        {
            book.BookId = dataSource.Books.Count > 0
                ? (dataSource.Books[dataSource.Books.Count - 1].BookId + 1)
                : 1;
            dataSource.Books.Add(book);
            return book;
        }

        public void UpdateBook(Book book)
        {
            var foundBook = dataSource.Books.FirstOrDefault(s => s.BookId == book.BookId);
            if (foundBook == null)
            {
                return;
            }

            foundBook.Isbn = book.Isbn;
            foundBook.Pages = book.Pages;
            foundBook.PublishDate = book.PublishDate;
            foundBook.Publisher = book.Publisher;
            foundBook.Title = book.Title;
            foundBook.Image = book.Image;
        }

        public void DeleteBook(int bookId)
        {
            dataSource.Books.RemoveAll(s => s.BookId == bookId);
        }
    }
}
