using Bogus;
using Microsoft.EntityFrameworkCore;
using Spg.DomainLinQ.App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;
using static System.Formats.Asn1.AsnWriter;
using Gender = Spg.DomainLinQ.App.Model.Gender;

namespace Spg.DomainLinQ.App.Infrastructure
{
    /// <summary>
    /// * DB-Sets (1P)
    /// * Constructors (1P)
    /// * Methoden (2P)
    /// Den Inhalt der Seed-Methode, nach vollständiger implementierung, einkommentieren
    /// </summary>
    public class Shop2000Context : DbContext
    {
        // TODO: Implementation

        /// <summary>
        /// TODO: Ist zu entfernen und durch den tatsächlichen Konstruktor zu ersetzen
        /// </summary>
        /// <param name="nonsense"></param>
        
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Price> Prices => Set<Price>();

        // 3. Leerkonstruktor
        public Shop2000Context()
        { }

        // Konstruktor mit Basisklasse (Context)
        public Shop2000Context(DbContextOptions options)
            : base(options)
        { }

        // 4. Konfiguration vor DB Erstellung
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //{
            // optionsBuilder.UseSqlite("Data Source = Server= 142.147.258.169; DataBase=myDataBase; User Id= Ich; Password=Geheim!");
            //}
            //werden bei UnitTest festgelegt
            //wird auf Git gepusht, es hilft uns nicht wenn wir die Connetion hier haben
            //wir müssen die optionsBuilder außerhalb deklarieren 
        }

        // 5. Optionen während DB Erstellung
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys, nur, wenn Primary Key != int Id
            // modelBuilder.Entity<Teacher>().HasKey(p => p.Name);
            // modelBuilder.Entity<Teacher>().Property(p => p.Name).IsRequired();


            modelBuilder.Entity<Product>().HasKey(p => p.Description);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();

            modelBuilder.Entity<User>().HasKey(p => p.RegistrationNumber);
            modelBuilder.Entity<User>().Property(p => p.RegistrationNumber).IsRequired();

            // Value Object
            // 1 : 1 -Beziehungen
            // Bei diesen kommt in den Klassen kein protected Leerkonstruktor
            modelBuilder.Entity<Supplier>().OwnsOne(s => s.BillingAddress);
            modelBuilder.Entity<Supplier>().OwnsOne(s => s.BusinessAddress);

            modelBuilder.Entity<User>().OwnsOne(u => u.BillingAddress);
            modelBuilder.Entity<User>().OwnsOne(u => u.BusinessAddress);

        }

        public void Seed()
        {
            Randomizer.Seed = new Random(130700);

            var departments = new string[] { "DEPT01", "DEPT02", "DEPT03", "DEPT04", "DEPT05", "DEPT06" };


            // Seed Suppliers
            var suppliers = new Faker<Supplier>("de")
                .CustomInstantiator(f =>
                new Supplier(
                    f.Name.FirstName(Bogus.DataSets.Name.Gender.Male),
                    f.Name.LastName(),
                    f.Internet.Email(),
                    f.Random.Guid(),
                    new Address(
                        f.Address.StreetName(),
                        f.Address.ZipCode(),
                        f.Address.City(),
                        f.Address.BuildingNumber()
                    ),
                    new Address(
                        f.Address.StreetName(),
                        f.Address.ZipCode(),
                        f.Address.City(),
                        f.Address.BuildingNumber()
                    )
                )
            )
            .Rules((f, t) =>
            {
                string firstName = String.Empty;
                t.LastChangeDate = f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now).Date.OrNull(f, 0.3f);
            })
            .Generate(250)
            .ToList();
            Suppliers.AddRange(suppliers);
            SaveChanges();


            // Seed Shops
            var shops = new Faker<Shop>()
                .CustomInstantiator(f =>
                new Shop(
                    f.Random.Int(1, 8) + f.Random.String2(1, "ABCDEF") + f.Random.ListItem(departments),
                    f.Random.Guid()
                )
            )
            .Rules((f, c) =>
            {
                c.LastChangeDate = f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now).Date.OrNull(f, 0.3f);
            })
            .Generate(12)
            .GroupBy(c1 => c1.Name)
            .Select(g => g.First())
            .ToList();
            Shops.AddRange(shops);
            SaveChanges();


            // Seed Products
            var products = new Faker<Product>("de")
                .CustomInstantiator(f =>
                new Product(
                    f.Commerce.ProductName(),
                    f.Commerce.Ean13(),
                    f.Random.Int(10, 1000),
                    f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now).Date.OrNull(f, 0.3f),
                    f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now).Date.OrNull(f, 0.3f),
                    f.Random.ListItem(shops)
                )
            )
            .Rules((f, su) =>
            {
            })
            .Generate(90)
            .GroupBy(c1 => c1.Description)
            .Select(g => g.First())
            .ToList();
            Products.AddRange(products);
            SaveChanges();


            // Seed Users
            var users = new Faker<User>("de")
                .CustomInstantiator(f =>
                new User(
                    f.Random.Int(11111, 99999),
                    f.Random.Guid(),
                    f.Name.FirstName(Bogus.DataSets.Name.Gender.Male),
                    f.Name.LastName(),
                    f.Internet.Email(),
                    f.Random.Enum<Gender>(new Gender[] { Gender.NA }),
                    f.Random.ListItem(shops),
                    new Address(
                        f.Address.StreetName(),
                        f.Address.ZipCode(),
                        f.Address.City(),
                        f.Address.BuildingNumber()
                    ),
                    new Address(
                        f.Address.StreetName(),
                        f.Address.ZipCode(),
                        f.Address.City(),
                        f.Address.BuildingNumber()
                    )
                )
            )
            .Rules((f, s) =>
            {
                if (s.Gender == Gender.FEMALE)
                {
                    s.FirstName = f.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                }
            })
            .Generate(240)
            .ToList();
            Users.AddRange(users);
            SaveChanges();


            foreach (User item in users)
            {
                item.AddProduct(products);
            }
            foreach (Supplier item in suppliers)
            {
                item.AddProduct(new Faker().Random.ListItem(products));
            }
            SaveChanges();


            // Seed Prices
            var exams = new Faker<Price>("de")
                .CustomInstantiator(f =>
                new Price(
                    f.Random.Decimal(10, 5000),
                    20,
                    f.Date.Between(DateTime.Now, DateTime.Now.AddYears(1)).Date,
                    f.Random.Guid(),
                    f.Random.ListItem(products))
                )
            .Rules((f, x) =>
            {
                x.LastChangeDate = f.Date.Between(new DateTime(2020, 1, 1), DateTime.Now).Date.OrNull(f, 0.3f);
            })
            .Generate(180)
            .ToList();
            Prices.AddRange(exams);
            SaveChanges();
        }
    }
}
