using System.Web.Mvc;
using BookList.Core.Models;
using BookList.Core.Repositories;

namespace BookList.Web.Controllers
{
    public class AuthorController : Controller
    {
        protected readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpPost]
        public JsonResult AuthorList(int bookId)
        {
            var authors = authorRepository.GetAuthorsOfBook(bookId);
            return Json(new { Result = "OK", Records = authors });
        }

        [HttpPost]
        public JsonResult CreateAuthor(Author author)
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

            var addeAuthor = authorRepository.AddAuthor(author);
            return Json(new { Result = "OK", Record = addeAuthor });
        }

        [HttpPost]
        public JsonResult UpdateAuthor(Author author)
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

            authorRepository.UpdateAuthor(author);
            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult DeleteAuthor(int authorId)
        {
            authorRepository.DeleteAuthor(authorId);
            return Json(new { Result = "OK" });
        }
    }
}
