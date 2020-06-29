using System;

namespace StoreApplication.Library
{
    public class Order

    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public decimal? Total { get; set; }


    }
}
