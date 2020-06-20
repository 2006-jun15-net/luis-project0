using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class Customer
    {


        public int CustomerID { get; set; } = 0;
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Order> OrderHistory { get; set;}


        public Customer(string FirstName, string LastName)
        {
            CustomerID++;
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.OrderHistory = new List<Order>();
        }


    }
}
