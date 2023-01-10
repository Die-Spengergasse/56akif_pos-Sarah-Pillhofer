using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * FirstName
    /// * LastName
    /// * EMail
    /// * BillingAddress
    /// * BusinessAddress
    /// * Guid
    /// (4P)
    /// </summary>
    public class Supplier : EntityBase
    {
        // TODO: Implementation
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public Address BillingAddress { get; set; } = default!;
        public Address BusinessAddress { get; set; } = default!;
        public Guid Guid { get; set; }


        private List<Product> _products = new();
        public virtual IReadOnlyList<Product> Products => _products;
        public void AddProduct(Product subject)
        {
            _products.Add(subject);
        }


        protected Supplier()
        { }

        public Supplier(string firstname, string lastname, 
            string eMail, Guid guid, Address billingAddress, Address businessAddress)
        {
            Firstname = firstname;
            Lastname = lastname;
            EMail = eMail;
            Guid = guid;
            BillingAddress = billingAddress;
            BusinessAddress = businessAddress;
        }
    }
}
