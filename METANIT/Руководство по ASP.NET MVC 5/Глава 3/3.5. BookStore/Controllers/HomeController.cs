using BookStore.Models;
using BookStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            //Получаем из БД все объекты Book
            IEnumerable<Book> books = db.Books;
            //Передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            //возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (id > 3)
            {
                return Redirect("/Home/Index");
            }
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = getToday();
            //Добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            //Сохряняем в бд все изменения
            db.SaveChanges();
            return "СПасибо, " + purchase.Person + ". за покупку!";
        }
        
        private DateTime getToday()
        {
            return DateTime.Now;
        }

        /*public string Square(int a = 10, int h = 3)
        {
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }*/

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImages()
        {
            string path = "../Content/Images/studio.jpg";
            return new ImageResult(path);
        }

        /*public ViewResult SomeMethod()
        {
            ViewData["Head"] = "Привет мир!";
            return View("SomeView");
        }*/

        public ViewResult SomeMethod()
        {
            ViewBag.Head = "Привет, мир!!";
            return View("SomeView");
        }

        public RedirectResult SomeMethod2()
        {
            return Redirect("/Home/Index");
        }

        public RedirectResult SomeMethod3()
        {
            return RedirectPermanent("/Home/Index");
        }

        public RedirectToRouteResult SomeMethod4()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public RedirectToRouteResult SomeMethod5()
        {
            return RedirectToAction("Square", "Home", new { a = 10, h = 12 });
        }

        public ActionResult Check(int age)
        {
            if (age < 21)
            {
                return new HttpStatusCodeResult(404);
            }
            return View();
        }

        public ActionResult Check2(int id)
        {
            if (id < 21)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Check3(int id)
        {
            if (id < 21)
            {
                return new HttpUnauthorizedResult();
            }
            return View();
        }
    }
}