using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Street
    /// * Zip
    /// * City
    /// * BuildungNumber
    /// (2P)
    /// </summary>
    public class Address
    {
        // TODO: Implementation
        public string Street { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string BuildungNumber { get; set; } = string.Empty;

        protected Address()
        { }
        public Address(string street, string zip, string city, string buildungNumber)
        {
            Street = street;
            Zip = zip;
            City = city;
            BuildungNumber = buildungNumber;
        }
    }
}
