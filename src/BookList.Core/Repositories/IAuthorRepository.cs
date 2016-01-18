using System.Collections.Generic;
using BookList.Core.Models;

namespace Hik.JTable.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorsOfStudent(int studentId);

        Author AddAuthor(Author author);

        void UpdateAuthor(Author author);

        void DeleteAuthor(int authorId);
    }
}
