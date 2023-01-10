using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.Domain.Model
{
    public enum Genders { Male,Female,Other}
    
    public class Customer
    {
        public int Id { get; }
        public Genders Gender { get; set; }
        public string CustomerNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public DateTime BirthDate { get; }
        public string? Address { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        private List<ShoppingCart> _shoppingCarts {get; set; } = new();
        public IReadOnlyList<ShoppingCart> ShoppingCarts => _shoppingCarts;

        //protected = man sieht es von außen nicht mehr, aber innerhalb der Vererbungshierarchie schon
        protected Customer()
        {
            
        }

        public Customer(Genders gender, string customerNumber, 
            string firstName, string lastName, string eMail, DateTime birthDate, 
            DateTime registrationDateTime, List<ShoppingCart> shoppingCarts)
        {
            Gender = gender;
            CustomerNumber = customerNumber;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            BirthDate = birthDate;
            RegistrationDateTime = registrationDateTime;
            _shoppingCarts = shoppingCarts;
        }
    }
}
