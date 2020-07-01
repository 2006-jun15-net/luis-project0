using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace StoreApplication.Library
{
    public class Product
    {
        private string _name;
        private decimal _price;
        public int ProductId { get; set; } = 0;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Product must have a name", nameof(value));
                }
                _name = value;
            }

        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The product price cannot be zero or negative.", nameof(value));
                }
                else
                {
                    _price = value;
                }
            }
        }


    }
}
