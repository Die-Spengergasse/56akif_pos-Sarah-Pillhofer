using Microsoft.EntityFrameworkCore;
using Spg.DomainLinQ.App.Infrastructure;
using Spg.DomainLinQ.App.Model;
using static Bogus.DataSets.Name;

namespace Spg.DomainLinQ.Domain.Test
{
    public class UnitTest1
    {
        private Shop2000Context GenerateDb()
        {
            //Datenbank erstellen
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source = Shop2000.db");
            Shop2000Context db = new Shop2000Context(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void Supplier_SuccessTest()
        {
            Shop2000Context db = GenerateDb();
            Supplier newSupplier = new Supplier("firstname", "lastname", "@email.com", Guid.NewGuid(),
                new Address("street", "zip", "city", "8"), new Address("street", "zip", "city", "7"));

            db.Suppliers.Add(newSupplier);
            db.SaveChanges();

            Assert.Equal(1, db.Suppliers.Count());
        }

        [Fact]
        public void Shops_SuccessTest()
        {
            Shop2000Context db = GenerateDb();
            Shop newShop = new Shop("shop", Guid.NewGuid());

            db.Shops.Add(newShop);
            db.SaveChanges();

            Assert.Equal(1, db.Shops.Count());
        }

        [Fact]
        public void Products_SuccessTest()
        {
            Shop2000Context db = GenerateDb();
            Product newProduct = new Product("description", "barcode", 5, DateTime.Now, DateTime.Now,
                new Shop("shop", Guid.NewGuid()));

            db.Products.Add(newProduct);
            db.SaveChanges();

            Assert.Equal(1, db.Products.Count());
        }

        [Fact]
        public void User_SuccessTest()
        {
            Shop2000Context db = GenerateDb();
            User newUser = new User(3, Guid.NewGuid(), "firstname", "lastname", "@email.com",
                Gender.FEMALE, new Shop("shop", Guid.NewGuid()),
                new Address("street", "zip", "city", "8"), new Address("street", "zip", "city", "7"));

            db.User.Add(newUser);
            db.SaveChanges();

            Assert.Equal(1, db.User.Count());
        }

        [Fact]
        public void Prices_SuccessTest()
        {
            Shop2000Context db = GenerateDb();
            Price newPrice = new Price(1.0, 20, DateTime.Now, Guid.NewGuid,
                new Product("description", "barcode", 4, DateTime.Now, DateTime.Now,
                new Shop("shop", Guid.NewGuid());

            db.Prices.Add(newPrice);
            db.SaveChanges();

            Assert.Equal(1, db.Prices.Count());
        }
    }
}