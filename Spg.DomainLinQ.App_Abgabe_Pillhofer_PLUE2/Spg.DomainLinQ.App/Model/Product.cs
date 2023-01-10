using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Description (PK)
    /// * Ean13;
    /// * Stock;
    /// * ExpiryDate;
    /// * DeliveryDate;
    /// * Price;
    /// * ShopNavigation
    /// (4P)
    /// </summary>
    public class Product
    {
        // TODO: Implementation
        public string Description { get; set; } = string.Empty;
        public string Ean13 { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }


        private List<Price> _prices = new();
        public virtual IReadOnlyList<Price> Prices => _prices;

        private List<Supplier> _supplier = new();
        public virtual IReadOnlyList<Supplier> Suppliers => _supplier;


        private List<User> _users = new();
        public virtual IReadOnlyList<User> Users => _users;

        public virtual Shop ShopNavigation { get; set; } = default!;
        public int ShopNavigationId { get; set; }


        protected Product()
        { }

        public Product(string description, string ean13, int stock, 
            DateTime expiryDate, DateTime deliveryDate, Shop shopNavigation)
        {
            Description = description;
            Ean13 = ean13;
            Stock = stock;
            ExpiryDate = expiryDate;
            DeliveryDate = deliveryDate;
            ShopNavigation = shopNavigation;
        }
    }
}
