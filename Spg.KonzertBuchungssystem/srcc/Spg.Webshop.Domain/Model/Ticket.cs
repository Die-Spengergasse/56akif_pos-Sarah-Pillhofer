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
    }
}
