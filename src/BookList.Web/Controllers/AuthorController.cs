using BookList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookList.Core.Repositories;
using BookList.Core.Repositories.Memory;

namespace AuthorList.Web.Controllers
{
    public class AuthorController : Controller
    {
        //IBookRepository bookRepository = new MemoryBookRepository();

        [HttpPost]
        public JsonResult AuthorList(Guid bookId)
        {
            //List<Author> authors = bookRepository.GetAllBooks().First(x => x.BookId.Equals(bookId)).Authors;
            return Json(new { Result = "OK", });
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

            //var book = bookRepository.GetAll().First(x => x.Id.Equals(bookId));
            //book.Authors.Add(author);
            //bookRepository.Save(book);
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

            //bookRepository.Update(author);
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult DeleteAuthor(Guid authorId, Guid bookId)
        {
            //bookRepository.Delete(authorId);
            return Json(new { Result = "OK" });
        }
    }
}
