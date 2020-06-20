using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace StoreApplication.Library
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        private double _price;
        public double Price 
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The price cannot be below zero");
                }
                _price = value;
            }
        }

        private int _quantity;
        public int Quantity 
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The quantity cannot be below zero");
                }
                _quantity = value;
            }
        }

        public Product(string Name, int Quantity)
        {
            this.ProductName = Name;
            this.Quantity = Quantity;


        }

    }
}
