using System;
using System.Collections.Generic;

namespace StoreApplication.Library
{
    public class Customer
    {
        private string _email;
        private string _firstName;
        private string _lastName;
        public int CustomerId { get; set; }
        public string Email
        {
            get => _email;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The customer must have an email to register.", nameof(value));
                }
                else
                {
                    _email = value;
                }
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The customer must have a First Name.", nameof(value));
                }
                else
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The customer must have a last name.", nameof(value));
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public List<Order> OrderHistory { get; set; } = new List<Order>();




    }
}
