
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.Library.Repositories

{
    /// <summary>
    /// A repository managing data access for restaurant objects and their review members.
    /// </summary>
    public class CustomerRepository
    {
        private readonly ICollection<Customer> _data;

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// </summary>
        /// <param name="data">The data source</param>
        public CustomerRepository(ICollection<Customer> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Get all restaurants with deferred execution.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Customer> GetCustomers(string search = null)
        {
            if (search == null)
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _data.Where(c => c.FirstName.Contains(search)))
                {
                    yield return item;
                }
            }
        }


        /// <summary>
        /// Add a Customer, as well as their order history.
        /// </summary>
        /// <param name="customer">The customer</param>
        public void AddCustomer(Customer customer)
        {
            if (_data.Any(c => c.CustomerID == customer.CustomerID))
            {
                throw new InvalidOperationException($"Customer with ID {customer.CustomerID} already exists.");
            }
            _data.Add(customer);
        }

       
        /// <summary>
        /// Add an order and associate it with a customer.
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        public void AddOrder(Order order, Customer customer)
        {
            customer.OrderHistory.Add(order);
        }

       
    }
}
