using AlWarraq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AlWarraq.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.isAuthenticated = isAuthenticated;
            ViewBag.Categorys = db.Categories.ToList();
            var books = db.Books;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var cart = db.Carts.Include(c => c.CartItems.Select(ci => ci.Book)).FirstOrDefault(c => c.UserId == userId);
                if (cart == null)
                {
                    cart = new Cart();
                    cart.UserId = userId;
                    db.Carts.Add(cart);
                }
                @ViewBag.itemsCount = cart.TotalAmount;
            }
            return View(books.ToList());
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}