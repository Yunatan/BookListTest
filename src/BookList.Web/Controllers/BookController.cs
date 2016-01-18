using BookList.Core.Models;
using System.Web.Mvc;
using BookList.Core.Repositories;
using Castle.Core.Internal;

namespace BookList.Web.Controllers
{
    public class BookController : Controller
    {
        protected readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpPost]
        public JsonResult BookList(string jtSorting)
        {
            var books = jtSorting.IsNullOrEmpty()
                ? bookRepository.GetAllBooks()
                : bookRepository.GetBooksSorted(jtSorting);
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
