using System.Collections.Generic;
using System.Linq;
using BookList.Core.Models;
using System;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryBookRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Book> GetAllBooks()
        {
            return _dataSource.Books.OrderBy(s => s.Name).ToList();
        }

        public List<Book> GetBooks(int startIndex, int count, string sorting)
        {
            IEnumerable<Book> query = _dataSource.Books;

            //Sorting
            //This ugly code is used just for demonstration.
            //Normally, Incoming sorting text can be directly appended to an SQL query.
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC"))
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(p => p.Name);
            }
            else if (sorting.Equals("Gender ASC"))
            {
                query = query.OrderBy(p => p.Gender);
            }
            else if (sorting.Equals("Gender DESC"))
            {
                query = query.OrderByDescending(p => p.Gender);
            }
            else if (sorting.Equals("CityId ASC"))
            {
                query = query.OrderBy(p => p.CityId);
            }
            else if (sorting.Equals("CityId DESC"))
            {
                query = query.OrderByDescending(p => p.CityId);
            }
            else if (sorting.Equals("BirthDate ASC"))
            {
                query = query.OrderBy(p => p.BirthDate);
            }
            else if (sorting.Equals("BirthDate DESC"))
            {
                query = query.OrderByDescending(p => p.BirthDate);
            }
            else if (sorting.Equals("IsActive ASC"))
            {
                query = query.OrderBy(p => p.IsActive);
            }
            else if (sorting.Equals("IsActive DESC"))
            {
                query = query.OrderByDescending(p => p.IsActive);
            }
            else
            {
                query = query.OrderBy(p => p.Name); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }

        public List<Book> GetBooksByFilter(string name, int cityId, int startIndex, int count, string sorting)
        {
            IEnumerable<Book> query = _dataSource.Books;

            //Filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cityId > 0)
            {
                query = query.Where(p => p.CityId == cityId);
            }

            //Sorting
            //This ugly code is used just for demonstration.
            //Normally, Incoming sorting text can be directly appended to an SQL query.
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC"))
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(p => p.Name);
            }
            else if (sorting.Equals("Gender ASC"))
            {
                query = query.OrderBy(p => p.Gender);
            }
            else if (sorting.Equals("Gender DESC"))
            {
                query = query.OrderByDescending(p => p.Gender);
            }
            else if (sorting.Equals("CityId ASC"))
            {
                query = query.OrderBy(p => p.CityId);
            }
            else if (sorting.Equals("CityId DESC"))
            {
                query = query.OrderByDescending(p => p.CityId);
            }
            else if (sorting.Equals("BirthDate ASC"))
            {
                query = query.OrderBy(p => p.BirthDate);
            }
            else if (sorting.Equals("BirthDate DESC"))
            {
                query = query.OrderByDescending(p => p.BirthDate);
            }
            else if (sorting.Equals("IsActive ASC"))
            {
                query = query.OrderBy(p => p.IsActive);
            }
            else if (sorting.Equals("IsActive DESC"))
            {
                query = query.OrderByDescending(p => p.IsActive);
            }
            else
            {
                query = query.OrderBy(p => p.Name); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }

        public Book AddBook(Book book)
        {
            book.BookId = _dataSource.Books.Count > 0
                                    ? (_dataSource.Books[_dataSource.Books.Count - 1].BookId + 1)
                                    : 1;
            _dataSource.Books.Add(book);
            return book;
        }

        public void UpdateBook(Book book)
        {
            var foundBook = _dataSource.Books.FirstOrDefault(s => s.BookId == book.BookId);
            if (foundBook == null)
            {
                return;
            }

            foundBook.Name = book.Name;
            foundBook.EmailAddress = book.EmailAddress;
            foundBook.Password = book.Password;
            foundBook.Gender = book.Gender;
            foundBook.BirthDate = book.BirthDate;
            foundBook.CityId = book.CityId;
            foundBook.About = book.About;
            foundBook.Education = book.Education;
            foundBook.IsActive = book.IsActive;
        }

        public void DeleteBook(int bookId)
        {
            _dataSource.Books.RemoveAll(s => s.BookId == bookId);
        }

        public int GetBookCount()
        {
            return _dataSource.Books.Count;
        }


        public int GetBookCountByFilter(string name, int cityId)
        {
            IEnumerable<Book> query = _dataSource.Books;

            //Filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cityId > 0)
            {
                query = query.Where(p => p.CityId == cityId);
            }

            return query.Count();
        }
    }
}
