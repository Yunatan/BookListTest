using System.Web.Mvc;
using BookList.Web.Models;

namespace BookList.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(JtGridModel model)
        {
            return View(model);
        }
    }
}