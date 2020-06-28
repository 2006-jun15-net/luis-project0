using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;

namespace StoreApplication.Library
{
    public class Customer
    {
        static int nextID;
        public int CustomerID { get;  set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Order> OrderHistory { get; set;}


        public Customer(string FirstName, string LastName)
        {
            CustomerID = Interlocked.Increment(ref nextID);

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.OrderHistory = new List<Order>();
        }



    }
}
