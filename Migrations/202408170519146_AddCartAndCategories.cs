namespace AlWarraq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddCartAndCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                {
                    BookId = c.Int(nullable: false),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.BookId, t.CategoryId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.CartItems",
                c => new
                {
                    CartItemId = c.Int(nullable: false, identity: true),
                    CartId = c.Int(nullable: false),
                    BookId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.BookId);

            CreateTable(
                "dbo.Carts",
                c => new
                {
                    CartId = c.Int(nullable: false, identity: true),
                    UserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    ReviewId = c.Int(nullable: false, identity: true),
                    BookId = c.Int(nullable: false),
                    UserId = c.String(maxLength: 128),
                    Rating = c.Int(nullable: false),
                    Comment = c.String(nullable: false),
                    ReviewDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            Sql("INSERT INTO Categories (Name) VALUES ('Fiction')");
            Sql("INSERT INTO Categories (Name) VALUES ('Science')");
            Sql("INSERT INTO Categories (Name) VALUES ('History')");
            Sql("INSERT INTO Categories (Name) VALUES ('Technology')");
            Sql("INSERT INTO Categories (Name) VALUES ('Children')");
            Sql("INSERT INTO Categories (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO Categories (Name) VALUES ('Romance')");
            Sql("INSERT INTO Categories (Name) VALUES ('Thriller')");
            Sql("INSERT INTO Categories (Name) VALUES ('Mystery')");
            Sql("INSERT INTO Categories (Name) VALUES ('Biography')");
            Sql("INSERT INTO Categories (Name) VALUES ('Self-Help')");
            Sql("INSERT INTO Categories (Name) VALUES ('Travel')");
            Sql("INSERT INTO Categories (Name) VALUES ('Cooking')");
            Sql("INSERT INTO Categories (Name) VALUES ('Art')");
            Sql("INSERT INTO Categories (Name) VALUES ('Photography')");
            Sql("INSERT INTO Categories (Name) VALUES ('Health')");
            Sql("INSERT INTO Categories (Name) VALUES ('Business')");
            Sql("INSERT INTO Categories (Name) VALUES ('Education')");
            Sql("INSERT INTO Categories (Name) VALUES ('Sports')");
            Sql("INSERT INTO Categories (Name) VALUES ('Comics')");

            //// Books

            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('The Great Gatsby', 'F. Scott Fitzgerald', '9780743273565', 10.99, 50, '/images/the-great-gatsby.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('1984', 'George Orwell', '9780451524935', 8.99, 40, '/images/1984.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('To Kill a Mockingbird', 'Harper Lee', '9780060935467', 7.99, 30, '/images/to-kill-a-mockingbird.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Pride and Prejudice', 'Jane Austen', '9780141439518', 9.99, 20, '/images/pride-and-prejudice.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('The Catcher in the Rye', 'J.D. Salinger', '9780316769488', 10.49, 35, '/images/the-catcher-in-the-rye.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('The Hobbit', 'J.R.R. Tolkien', '9780547928227', 11.99, 25, '/images/the-hobbit.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Moby Dick', 'Herman Melville', '9781503280786', 12.99, 15, '/images/moby-dick.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('War and Peace', 'Leo Tolstoy', '9781420958618', 14.99, 10, '/images/war-and-peace.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Crime and Punishment', 'Fyodor Dostoevsky', '9780486415871', 9.99, 20, '/images/crime-and-punishment.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('The Odyssey', 'Homer', '9780140268867', 13.99, 12, '/images/the-odyssey.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Brave New World', 'Aldous Huxley', '9780060850524', 8.99, 30, '/images/brave-new-world.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Jane Eyre', 'Charlotte Brontë', '9780142437209', 9.99, 25, '/images/jane-eyre.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Wuthering Heights', 'Emily Brontë', '9780553212587', 7.99, 20, '/images/wuthering-heights.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('Great Expectations', 'Charles Dickens', '9780141439563', 10.99, 18, '/images/great-expectations.jpg')");
            //Sql("INSERT INTO Books (Title, Author, ISBN, Price, StockQuantity, ImageUrl) VALUES ('The Lord of the Rings', 'J.R.R. Tolkien', '9780544003415', 15.99, 10, '/images/the-lord-of-the-rings.jpg')");

            //// Add Categories and associate with Books
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (1, 1)"); // The Great Gatsby - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (2, 2)"); // 1984 - Science Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (3, 1)"); // To Kill a Mockingbird - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (4, 1)"); // Pride and Prejudice - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (5, 1)"); // The Catcher in the Rye - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (6, 6)"); // The Hobbit - Fantasy
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (7, 7)"); // Moby Dick - Adventure
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (8, 3)"); // War and Peace - History
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (9, 1)"); // Crime and Punishment - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (10, 4)"); // The Odyssey - Epic
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (11, 2)"); // Brave New World - Science Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (12, 8)"); // Jane Eyre - Romance
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (13, 8)"); // Wuthering Heights - Romance
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (14, 1)"); // Great Expectations - Fiction
            //Sql("INSERT INTO BookCategories (BookId, CategoryId) VALUES (15, 6)"); // The Lord of the Rings - Fantasy

            DropColumn("dbo.OrderDetails", "UnitPrice");
        }

        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BookCategories", "BookId", "dbo.Books");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.CartItems", new[] { "BookId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropIndex("dbo.BookCategories", new[] { "CategoryId" });
            DropIndex("dbo.BookCategories", new[] { "BookId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
            DropTable("dbo.Categories");
            DropTable("dbo.BookCategories");
        }
    }
}
