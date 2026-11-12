using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Almisbah_library.Models;

namespace Almisbah_library.Controllers
{
    public class CartController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {

            var cart = Session["Cart"] as List<int>;
            if (cart == null) cart = new List<int>();
            var books = db.Books.Where(b => cart.Contains(b.Id)).ToList();
            ViewBag.Total = books.Sum(b => b.Price);
            return View(books);
        }

        public ActionResult AddToCart(int id)
        {
            var cart = Session["Cart"] as List<int>;
            if (cart == null) cart = new List<int>();
            cart.Add(id);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()

        {
            var cart = Session["Cart"] as List<int>;
            if (cart != null)
            {
                var total = db.Books.Where(b => cart.Contains(b.Id)).Sum(b => b.Price);
                Session["Total"] = total;
            }
            Session["Cart"] = null; // فضي السلة
            return View(); // حيفتح Views/Cart/Checkout.cshtml
        }
    }
}