using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList.Core.Models;

namespace BookList.Core.Services
{
    public interface IBookRepository
    {
        Book Save(Book newBook);

        void Update(Book newBook);

        List<Book> GetAll();

        void Delete(Guid bookId);
    }
}
