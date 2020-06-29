using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace StoreApplication.Library
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
