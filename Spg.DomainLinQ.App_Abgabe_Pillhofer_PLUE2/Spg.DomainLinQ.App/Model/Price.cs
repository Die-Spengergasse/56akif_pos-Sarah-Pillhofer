using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * PriceGross (wird durch PriceNet und Tax ermittelt)
    /// * PriceNett
    /// * Tax
    /// * Created
    /// * Guid
    /// (4P)
    /// </summary>
    public class Price : EntityBase
    {
        // TODO: Implementation
        public decimal PriceGross => PriceNett + (PriceNett*Tax/100); 
        public decimal PriceNett { get; set; } = default!;
        public int Tax { get; set; } // Angabe in Prozent
        public DateTime Created { get; set; }
        public Guid Guid { get; set; }

        public virtual Product ProductNavigation { get; set; } = default!;
        public int ProductNavigationId { get; set; }


        protected Price()
        { }

        public Price(decimal priceNett, int tax, DateTime created, Guid guid, Product productNavigation)
        {
            PriceNett = priceNett;
            Tax = tax;
            Created = created;
            Guid = guid;
            ProductNavigation = productNavigation;
        }
    }
}
