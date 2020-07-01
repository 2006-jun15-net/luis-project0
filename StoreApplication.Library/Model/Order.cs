using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class Order

    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime? TimeOfOrder { get; set; } = null;
        public decimal? _Total { get; set; }

        public Dictionary<Product, int> OrderLine { get; set; } = new Dictionary<Product, int>();

        public decimal? Total
        {
            get
            {
                if (OrderLine.Count == 0)
                {
                    throw new Exception("The order requires at least one Orderline.");
                }
                foreach (var p in OrderLine.Keys)
                {
                    _Total += p.Price * OrderLine[p];
                }
                return _Total;
            }
            set => _Total = value;
        }




    }
}
