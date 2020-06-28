using System;
using System.Collections.Generic;

namespace StoreApplication.DatabaseAccess.Model
{
    public partial class Inventory
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual StoreLocations Location { get; set; }
        public virtual Products Product { get; set; }
    }
}
