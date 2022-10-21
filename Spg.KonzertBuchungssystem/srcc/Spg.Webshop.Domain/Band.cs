using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KonzertBuchungssystem.Domain
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AnzahlMitglieder { get; set; }
        public DateOnly Gruendungsdatum { get; set; }
    }
}
