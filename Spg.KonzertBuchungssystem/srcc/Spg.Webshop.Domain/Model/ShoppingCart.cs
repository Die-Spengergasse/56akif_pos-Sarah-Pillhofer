using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.Domain.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ItemsCount { get; }
        public Customer CustomerNavigation { get; set; } = default!;
        public List<Ticket> tickets { get; set; } = new();
    }
}
