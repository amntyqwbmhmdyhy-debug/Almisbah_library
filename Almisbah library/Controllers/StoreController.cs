using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Almisbah_library.Models;

namespace Almisbah_library.Controllers
{
    public class StoreController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index(string search)
        {
            var books = db.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                books = books.Where(b => b.Title.Contains(search));
            return View(books.ToList());
        }
        public ActionResult Details(int id)
        {
            var book = db.Books.Find(id);
            return View(book);

        }
    }
}
