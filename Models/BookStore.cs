using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlWarraq.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;



    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public decimal TotalAmount { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice
        {
            get
            {
                return Book?.Price ?? 0;
            }
        }
    }

    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return CartItems?.Sum(ci => ci.Quantity * ci.Book.Price) ?? 0;
            }
        }
    }

    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice
        {
            get
            {
                return Book?.Price ?? 0;
            }
        }
    }

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public int Rating { get; set; } // Rating out of 5

        [Required]
        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }

    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}