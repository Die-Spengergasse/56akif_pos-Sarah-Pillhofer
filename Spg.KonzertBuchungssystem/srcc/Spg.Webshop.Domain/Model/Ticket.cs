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
        public Band Band { get; set; } = default!;
        public DateTime ConcertDateAndTime { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
