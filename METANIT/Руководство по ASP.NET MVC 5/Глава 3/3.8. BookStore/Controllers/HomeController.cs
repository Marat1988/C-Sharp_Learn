using BookStore.Models;
using BookStore.Util;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            var b1 = db.Books;
            var books = (from b in db.Books
                         select new BookViewModel
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Author = b.Author,
                             Price = b.Price + b.Id,
                             Create  = new DateTime(2022,1,1)
                         }).AsQueryable();
            //Получаем из БД все объекты Book
            //IEnumerable<Book> books = db.Books;
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

        /*3.6.................................................*/
        public FileResult GetFile()
        {
            string file_path = Server.MapPath("~/Files/Video.pdf");
            string file_type = "application/pdf";
            string file_name = "Video.pdf";
            return File(file_path, file_type, file_name);
        }

        public FileResult GetBytes()
        {
            string path = Server.MapPath("~/Files/Video.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string fyle_type = "application/pdf";
            string file_name = "Vidio.pdf";
            return File(mas, fyle_type, file_name);
        }

        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Files/Video.pdf");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "Video.pdf";
            return File(fs, file_type, file_name);
        }

        /*3.7..................................................*/
        /*public string Index()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string reffer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p>" +
                "<p>User-Agent: " + user_agent + "</p>" +
                "<p>Url запроса: " + url + "</p>" +
                "<p>Реферер: " + reffer + "</p>" +
                "<p>IP-адрес: " + ip + "</p>";
        }*/

        public string ContexData()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");

            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string reffer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>User-Agent: " + user_agent + "</p>" +
                "<p>Url запроса: " + url + "</p>" +
                "<p>Реферер: " + reffer + "</p>" +
                "<p>IP-адрес: " + ip + "</p>";
        }

        public string GetCookie()
        {
            HttpContext.Response.Cookies["id"].Value = "Hello guys";
            string id = HttpContext.Request.Cookies["id"].Value;
            return "<p>Cookie id value is " + id + "</p>";

        }

        public string GetSession()
        {
            Session["name"] = "Tom";
            var val = Session["name"];
            return val.ToString();
        }

        /*3.8..................................................*/
        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();

            var data = (from b in books
                         select new BookViewModel
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Author = b.Author,
                             Price = b.Price + b.Id,
                             Create = new DateTime(2022, 1, 1)
                         }).AsQueryable();
            ViewBag.Books = data;
            return View();

       
        }


    }
}