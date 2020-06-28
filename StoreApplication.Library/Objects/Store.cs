using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StoreApplication.Library
{
    public class Store
    {
        static int nextID;
        public int StoreID { get; set; }

        public string Location { get; set; }

        public List<Product> Inventory { get; set; }

        public List<Order> OrderHistory { get; set; }

        public Store(string location)
        {
            StoreID = Interlocked.Increment(ref nextID);

            this.Location = Location;

            this.Inventory = new List<Product>();
            this.OrderHistory = new List<Order>();

        }
    }
}
