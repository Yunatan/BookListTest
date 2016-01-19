using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using BookList.Core.Models;
using System.Web.Mvc;
using BookList.Core.Repositories;
using Castle.Core.Internal;

namespace BookList.Web.Controllers
{
    public class BookController : Controller
    {
        protected readonly IBookRepository bookRepository;

        private readonly byte[] placeholderImage = ImageToByte(Images.PlaceholderBook);
        private readonly string placeholderImageType = "image/png";

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpPost]
        public JsonResult UploadBookImage(HttpPostedFileBase coverimg, int bookId)
        {
            var book = bookRepository.GetAllBooks().First(x => x.BookId.Equals(bookId));

            book.ImageType = coverimg.ContentType;
            using (var binaryReader = new BinaryReader(coverimg.InputStream))
            {
                book.Image = binaryReader.ReadBytes(coverimg.ContentLength);
            }

            bookRepository.UpdateBook(book);
            return Json(new { Result = "OK" });
        }

        [HttpGet]
        public FileResult GetBookImage(int bookId)
        {
            var book = bookRepository.GetAllBooks().First(x => x.BookId.Equals(bookId));

            return File(book.Image ?? placeholderImage, book.ImageType ?? placeholderImageType);
        }

        [HttpPost]
        public JsonResult BookList(string jtSorting)
        {
            var books = jtSorting.IsNullOrEmpty()
                ? bookRepository.GetAllBooks()
                : bookRepository.GetBooksSorted(jtSorting);
            return Json(new { Result = "OK", Records = books, Sorting = jtSorting });
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

        private static byte[] ImageToByte(Image img)
        {
            byte[] byteArray;
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }
    }
}
