using System;
using System.Collections.Generic;

namespace StoreApplication.DatabaseAccess.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PrefferedLocation { get; set; }
        public string Email { get; set; }

        public virtual StoreLocations PrefferedLocationNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
