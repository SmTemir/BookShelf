using BookShelf.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShelf.Data.Queries;
using BookShelf.Data.Entities;

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

        public void Insert(Book book)
        {
            bookRepository.Insert(book);
        }

        public void Update(Book book)
        {
            bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            bookRepository.Delete(id);
        }
    }
}