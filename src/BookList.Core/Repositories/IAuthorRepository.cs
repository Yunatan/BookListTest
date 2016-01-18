using System.Collections.Generic;
using BookList.Core.Models;

namespace BookList.Core.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorsOfBook(int bookId);

        Author AddAuthor(Author author);

        void UpdateAuthor(Author author);

        void DeleteAuthor(int authorId);
    }
}
