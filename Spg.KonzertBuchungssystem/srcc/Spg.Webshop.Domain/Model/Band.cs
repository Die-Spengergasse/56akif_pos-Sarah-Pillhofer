using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.model
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfMembers { get; set; }
        public DateOnly FoundingDate { get; set; }
    }
}
