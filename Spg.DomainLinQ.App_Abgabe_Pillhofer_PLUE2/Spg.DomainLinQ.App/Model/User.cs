using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * RegistrationNumber (PK)
    /// * FirstName
    /// * LastName
    /// * EMail
    /// * BillingAddress
    /// * BusinessAddress
    /// * AccountName = [Die ersten 5 Stellen des LastName + RegistrationNumber]
    /// * Gender
    /// * Guid
    /// (4P)s
    /// </summary>
    public class User
    {
        // TODO: Implementation
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public Address BillingAddress { get; set; } = default!;
        public Address BusinessAddress { get; set; } = default!;
        public string AccountName => $"{Lastname.Substring(0, 5)}{RegistrationNumber}";
        public Gender Gender { get; set; }
        public Guid Guid { get; set; }


        private List<Product> _products = new();
        public virtual IReadOnlyList<Product> Products => _products;
        public void AddProduct(List<Product> product)
        {
            _products.AddRange(product);
        }

        public virtual Shop ShopNavigation { get; set; } = default!;
        public int ShopNavigationId { get; set; }


        protected User()
        { }
        public User(int registrationNumber, Guid guid, string firstname, string lastname, 
            string eMail, Gender gender, Shop shopNavigation, Address billingAddress, 
            Address businessAddress)
        {
            RegistrationNumber = registrationNumber;
            Guid = guid;
            FirstName = firstname;
            Lastname = lastname;
            EMail = eMail;
            Gender = gender;
            ShopNavigation = shopNavigation;
            BillingAddress = billingAddress;
            BusinessAddress = businessAddress;
        }
    }
}
