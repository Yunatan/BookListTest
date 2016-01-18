using BookList.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BookList.Core.Repositories;
using BookList.Core.Repositories.Memory;

namespace BookList.Web.Controllers
{
    public class BookController : Controller
    {
        readonly IBookRepository bookRepository = new MemoryBookRepository(null);

        [HttpPost]
        public JsonResult BookList()
        {
            List<Book> books = bookRepository.GetAllBooks();
            return Json(new { Result = "OK", Records = books });
        }

        [HttpPost]
        public JsonResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Form is not valid! " +
                  "Please correct it and try again."
                });
            }

            var addedBook = bookRepository.AddBook(book);
            return Json(new { Result = "OK", Record = addedBook });
        }

        [HttpPost]
        public JsonResult UpdateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Form is not valid! " +
                    "Please correct it and try again."
                });
            }

            bookRepository.UpdateBook(book);
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult DeleteBook(int bookId)
        {
            bookRepository.DeleteBook(bookId);
            return Json(new { Result = "OK" });
        }
    }
}
