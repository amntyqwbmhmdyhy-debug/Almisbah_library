using System.Linq;
using System.Web.Mvc;
using Almisbah_library.Models;

namespace Almisbah_library.Controllers

{
    public class BookController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            book.Category = null;
            book.CategoryId = null;
            if (ModelState.IsValid)

            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // تعديل - يعرض البيانات
        public ActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            book.Category = null;
            book.CategoryId = null;
            db.Entry(book).State =

System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // حذف - يحذف مباشر بدون صفحة تأكيد
        public ActionResult Delete(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}