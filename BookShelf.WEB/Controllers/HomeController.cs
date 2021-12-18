using BookShelf.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShelf.Data.Queries;

namespace BookShelf.WEB.Controllers
{
    public class HomeController : Controller
    {
        private BookRepository bookRepository = new BookRepository();
        public ActionResult Index()
        {
            var books = bookRepository.List(new BookQuery());
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}