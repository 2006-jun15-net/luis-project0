using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StoreApplication.Library
{
    public class Order

        
    {

        static int nextID;

        public int OrderID { get; set; }

        public string CustomerName { get; set; }

        public string StoreLocation { get; set; }

        public DateTime OrderPlacedAt { get; set; }

        public double Total { get; set; }

        public List<Product> Cart { get; set; }

        public Order(string Product, int Quantity, string StoreLocation)
        {
            OrderID = Interlocked.Increment(ref nextID);
            this.OrderID = OrderID;
           

            this.OrderPlacedAt = DateTime.Now;
        }
    }
}
