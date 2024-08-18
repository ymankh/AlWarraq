using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using AlWarraq.Models;
using Microsoft.AspNet.Identity;

namespace AlWarraq.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var user = User.Identity;
            var userId = user.GetUserId();
            var userCart = db.Carts.Include(cart => cart.CartItems.Select(ci => ci.Book)).FirstOrDefault(cart => cart.UserId == userId);
            if (userCart != null) return View(userCart.CartItems.ToList());
            userCart = new Cart
            {
                UserId = user.GetUserId()
            };
            db.Carts.Add(userCart);
            db.SaveChanges();
            var cartItems = userCart.CartItems.ToList();
            return View(cartItems);
        }

        [Authorize]
        public ActionResult AddQuantity(int? id)
        {
            var cartItem = db.CartItems.Find(id);
            if (cartItem == null) return Index();
            cartItem.Quantity++;
            db.CartItems.AddOrUpdate(cartItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult MinusQuantity(int? id)
        {
            var cartItem = db.CartItems.Find(id);
            if (cartItem == null) return Index();
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            db.CartItems.AddOrUpdate(cartItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AddToCart(int bookId)
        {

            var book = db.Books.Find(bookId);
            if (book == null) return Json(new { success = false });

            var userId = User.Identity.GetUserId();

            var cart = db.Carts.Include(cart1 => cart1.CartItems).FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };
                db.Carts.Add(cart);
                db.SaveChanges();
            }

            var cartItem = cart.CartItems.FirstOrDefault(c => c.BookId == bookId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new CartItem { BookId = bookId, Quantity = 1 };
                cart.CartItems.Add(cartItem);
            }

            db.SaveChanges();
            // Optionally, you can return the updated cart details or just a success message
            return Json(new { success = true, itemCount = cart.CartItems.Count() });
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