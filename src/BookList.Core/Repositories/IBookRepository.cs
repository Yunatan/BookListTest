using System.Collections.Generic;
using BookList.Core.Models;

namespace BookList.Core.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        List<Book> GetBooksSorted(string sorting);

        Book AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int bookId);
    }
}
