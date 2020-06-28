using System;
using System.Collections.Generic;

namespace StoreApplication.DatabaseAccess.Model
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderLines>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
