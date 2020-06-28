using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library.Repositories
{
    class OrderRepository
    {
        private readonly ICollection<Order> _data;

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// </summary>
        /// <param name="data">The data source</param>
        public OrderRepository(ICollection<Order> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Get all restaurants with deferred execution.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Order> GetOrdersByName(string search = null)
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
                foreach (var item in _data.Where(o => o.CustomerName.Contains(search)))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<Order> GetOrdersByStore(string search = null)
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
                foreach (var item in _data.Where(o =>  o.StoreLocation.Contains(search)))
                {
                    yield return item;
                }
            }
        }

    }
}
