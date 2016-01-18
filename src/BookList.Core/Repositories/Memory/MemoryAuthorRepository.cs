using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookList.Core.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryAuthorRepository : IAuthorRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryAuthorRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public List<Author> GetAuthorsOfBook(int bookId)
        {
            return _dataSource.Authors.Where(e => e.BookId == bookId).ToList();
        }

        public Author AddAuthor(Author author)
        {
            author.AuthorId = _dataSource.Authors.Count > 0 ? (_dataSource.Authors[_dataSource.Authors.Count - 1].AuthorId + 1) : 1;
            _dataSource.Authors.Add(author);
            return author;
        }

        public void UpdateAuthor(Author author)
        {
            var foundAuthor = _dataSource.Authors.FirstOrDefault(e => e.AuthorId == author.AuthorId);
            if (foundAuthor == null)
            {
                return;
            }

            foundAuthor.CourseName = author.CourseName;
            foundAuthor.Degree = author.Degree;
            foundAuthor.AuthorDate = author.AuthorDate;
        }

        public void DeleteAuthor(int authorId)
        {
            _dataSource.Authors.RemoveAll(e => e.AuthorId == authorId);
        }
    }
}
