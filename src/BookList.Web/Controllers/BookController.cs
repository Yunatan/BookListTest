using BookList.Core.Models;
using BookList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookList.Web.Controllers
{
    public class BookController : Controller
    {
        IBookRepository _bookRepository = new MemoryBookRepository();

        [HttpPost]
        public JsonResult BookList()
        {
            List<Book> books = _bookRepository.GetAll();
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

            var addedBook = _bookRepository.Save(book);
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

            _bookRepository.Update(book);
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult DeleteBook(Guid bookId)
        {
            _bookRepository.Delete(bookId);
            return Json(new { Result = "OK" });
        }
    }
}
