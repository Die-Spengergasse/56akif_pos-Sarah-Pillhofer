using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Name
    /// * Department [Die ersten 3 Zeichen von Name]
    /// * Guid
    /// (4P)
    /// </summary>
    public class Shop : EntityBase
    {
        //TODO: Implementation
        public string Name { get; set; } = string.Empty;
        public string Department => Name.Substring(0, 3);
        public Guid Guid { get; private set; }


        private List<Product> _products = new();
        public virtual IReadOnlyList<Product> Products => _products;

        private List<User> _users = new();
        public virtual IReadOnlyList<User> Users => _users;
        
        protected Shop()
        { }
        public Shop(string name, Guid guid)
        {
            Name = name;
            Guid = guid;
        }
    }
}
