using System.Collections.Generic;
using System.Linq;
using BookList.Core.Models;

namespace BookList.Core.Repositories.Memory
{
    public class MemoryAuthorRepository : IAuthorRepository
    {
        private readonly MemoryDataSource dataSource;

        public MemoryAuthorRepository(MemoryDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        
        public List<Author> GetAuthorsOfBook(int bookId)
        {
            return dataSource.Authors.Where(e => e.BookId == bookId).ToList();
        }

        public Author AddAuthor(Author author)
        {
            author.AuthorId = dataSource.Authors.Count > 0
                ? (dataSource.Authors[dataSource.Authors.Count - 1].AuthorId + 1)
                : 1;
            dataSource.Authors.Add(author);
            return author;
        }

        public void UpdateAuthor(Author author)
        {
            var foundAuthor = dataSource.Authors.FirstOrDefault(e => e.AuthorId == author.AuthorId);
            if (foundAuthor == null)
            {
                return;
            }

            foundAuthor.FirstName = author.FirstName;
            foundAuthor.LastName = author.LastName;
        }

        public void DeleteAuthor(int authorId)
        {
            dataSource.Authors.RemoveAll(e => e.AuthorId == authorId);
        }
    }
}
