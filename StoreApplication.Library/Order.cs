using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        public int OrderID { get; set; } = 0;

        public string StoreLocation { get; set; }

        public DateTime OrderPlacedAt { get; set; }

        public List<Product> Cart { get; set; }

        public Order(string Product, int Quantity, string StoreLocation)
        {
            OrderID++;
            this.OrderID = OrderID;
           // if (StoreLocation == StoreDictionary.Location)
            {
                //this.storeLoction = StoreLocation
            }
            //this.cart = new List<Product>().append(product*quantity)

            this.OrderPlacedAt = DateTime.Now;
        }
    }
}
