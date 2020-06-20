using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Store
    {
        public int StoreID { get; set; }

        public string Location { get; set; }

        public List<Product> Inventory { get; set; }
    }
}
