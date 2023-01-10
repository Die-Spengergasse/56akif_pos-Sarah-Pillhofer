using Microsoft.EntityFrameworkCore.Query.Internal;
using Spg.DomainLinQ.App.Infrastructure;
using Spg.DomainLinQ.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Services
{
    /// <summary>
    /// (8P)
    /// </summary>
    public class LinQService
    {
        private readonly Shop2000Context _db;
        public LinQService(Shop2000Context db)
        {
            _db = db;
        }

        public void Start()
        {
            // Gebe jenen User mit der ID=8 zurück.  
            // registrationNumber nehmen
            var result01 = _db.Users.SingleOrDefault(u => u.RegistrationNumber == 8);
            Console.WriteLine($"Anzahl Datensätze 01: {result01.Count()}");

            // Erstelle eine Liste aller User, deren Nachname mit A beginnt.
            var result02 = _db.Users.Where(u => u.Lastname.StartsWith("A")).ToList();
            Console.WriteLine($"Anzahl Datensätze 02: {result02.Count()}");

            // Erstelle eine Liste aller Produkte, die keinen Preis eingetragen haben.
            var result03 = _db.Products.Count(p => !p.Prices.HasValue).ToList();
            Console.WriteLine($"Anzahl Datensätze 03: {result03.Count()}");

            // Gib das Produkt mit dem kleinsten Preis zurück.
            var result04 = _db.Products.Min(p => p.Prices);
            Console.WriteLine($"Anzahl Datensätze 04: {result04.Count()}");

            // Erstelle eine Liste aller User, deren Nachname mit C beginnt
            // und denen keine Produkte zugeordnet sind.
            var result05 = _db.Users.Where(u => u.Lastname.StartsWith("C") && u.Products == null).ToList();
            Console.WriteLine($"Anzahl Datensätze 05: {result05.Count()}");

            // Wieviele Produkte haben keinen einzigen Preis.
            var result06 = _db.Products.Where(p => !p.Prices.HasValue).Count();
            Console.WriteLine($"Ergebnis 06: {result06}");


            // Wieviele Produkte liegen im Preissegment zwischen 1000€ und 1500€.
            var result07 = _db.Products.Where(p => p.Prices.Any
            (p => p.PriceGross > 1000 && p.PriceGross < 1500)).Count();
            Console.WriteLine($"Ergebnis  07: {result07}");
        }
    }
}
