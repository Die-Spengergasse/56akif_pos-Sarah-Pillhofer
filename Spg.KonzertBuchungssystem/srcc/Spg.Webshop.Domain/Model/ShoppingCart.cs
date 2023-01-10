using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.Domain.Model
{
    public enum ShoppingCartStates {  Active = 0, Sent = 1, Unknown = 99 }

    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; }
        public int ItemsCount { get; }
        public decimal Sum{ get; }
        public ShoppingCartStates ShoppingCartState { get; set; }
        public Customer CustomerNavigation { get; set; } = default!;
        public List<Ticket> tickets { get; set; } = new();

        protected ShoppingCart()
        {
        
        }

        public ShoppingCart(DateTime creationDate, ShoppingCartStates shoppingCartState)
        {
            CreationDate = creationDate;
            ShoppingCartState = shoppingCartState;
        }
    }
}
