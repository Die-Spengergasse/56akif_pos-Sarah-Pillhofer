using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExProperties
{
    internal class Lehrer
    {
        private decimal? _bruttoGehalt;

        public string Vorname { get; set; } = string.Empty;
        public string Zuname { get; set; } = string.Empty;

        public string Kuerzel
        {
            get
            {
                if (Zuname.Length >= 3)
                {
                    return Zuname?.Substring(0, 3).ToUpper() ?? "--";
                }
                return "--";
            }
            
        }

        public decimal? Bruttogehalt
        {
            get
            {
                return _bruttoGehalt;
            }
            set      
            {
                if (_bruttoGehalt is not null)
                {
                    _bruttoGehalt = value;
                }
            }
        }
        public decimal Nettogehalt => _bruttoGehalt ?? 0 * 0.8M;
    }
}
