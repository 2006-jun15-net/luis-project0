using System;
using System.Collections.Generic;

namespace StoreApplication.DatabaseAccess.Model
{
    public partial class Orders
    {
        public Orders()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public decimal? Total { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual StoreLocations Location { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
