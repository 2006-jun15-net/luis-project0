using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StoreApplication.Library
{
    public class StoreLocation
    {
        public int StoreLocationId { get; set; }
        private string _name { get; set; }
        private string _address1 { get; set; }
        public string Address2 { get; set; }
        private string _city { get; set; }
        private string _state { get; set; }
        private string _zip { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The Store must have a name.", nameof(value));
                }
                _name = value;
            }
        }
        public string Address1
        {
            get => _address1;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The store must have an Address.", nameof(value));
                }
                _address1 = value;
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The store must have a City.", nameof(value));
                }
                _city = value;
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The store must have State.", nameof(value));
                }
                _state = value;
            }
        }
        public string Zip
        {
            get => _address1;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The store must have a Zip code.", nameof(value));
                }
                _zip = value;
            }
        }
        public Dictionary<Product, int> Inventory { get; set; } = new Dictionary<Product, int>();
    }


}

