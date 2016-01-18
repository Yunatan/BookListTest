using System.Collections.Generic;
using BookList.Core.Models;

namespace Hik.JTable.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        List<Book> GetBooks(int startIndex, int count, string sorting);

        List<Book> GetBooksByFilter(string name, int cityId, int startIndex, int count, string sorting);

        Book AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int bookId);

        int GetBookCount();

        int GetBookCountByFilter(string name, int cityId);
    }
}
