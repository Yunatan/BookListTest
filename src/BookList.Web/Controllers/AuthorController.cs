using BookList.Core.Models;
using BookList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthorList.Web.Controllers
{
    public class AuthorController : Controller
    {
        IBookRepository _bookRepository = new MemoryBookRepository();

        [HttpPost]
        public JsonResult AuthorList(Guid bookId)
        {
            List<Author> authors = _bookRepository.GetAll().First(x => x.BookId.Equals(bookId)).Authors;
            return Json(new { Result = "OK", Records = authors });
        }

        [HttpPost]
        public JsonResult CreateAuthor(Author author, Guid bookId)
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

            //var book = _bookRepository.GetAll().First(x => x.Id.Equals(bookId));
            //book.Authors.Add(author);
            //_bookRepository.Save(book);
            return Json(new { Result = "OK", Record = author });
        }

        [HttpPost]
        public JsonResult UpdateAuthor(Author author, Guid bookId)
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

            _bookRepository.Update(author);
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult DeleteAuthor(Guid authorId, Guid bookId)
        {
            _bookRepository.Delete(authorId);
            return Json(new { Result = "OK" });
        }
    }
}
