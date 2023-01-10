using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.Domain.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketCategory TicketCategory { get; set; } = default!;
        // konzertkategorie, sitzplatzkategorie, klasse show, klasse category, klasse kalender
        public ShoppingCart ShoppingCartNavigation { get; set; } = default!;

        protected Ticket()
        {

        }

        public Ticket(int id, TicketCategory ticketCategory, ShoppingCart shoppingCartNavigation)
        {
            Id = id;
            TicketCategory = ticketCategory;
            ShoppingCartNavigation = shoppingCartNavigation;
        }
    }
}
