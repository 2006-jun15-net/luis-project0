using StoreApplication.DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Mapper
    {
        public Customer DbModelToBusinessModel(Customers customer)
        {
            return new Customer { FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
        }

        public Customers BusinessModelToDbModel(Customer customer)
        {
            return new Customers { FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
        }

        public Order DbModelToBusinessModel(Orders order)
        {
            return new Order { OrderId = order.OrderId,
                OrderLine = (Dictionary<Product, int>)order.OrderLines,
                CustomerId = order.CustomerId,
                TimeOfOrder = order.TimeOfOrder,
                Total = order.Total
            };
        }
        public Orders BusinessModelToDbModel(Order order)
        {
            return new Orders
            {
                OrderId = order.OrderId,
                //OrderLines = order.OrderLines,
                CustomerId = order.CustomerId,
                TimeOfOrder = (DateTime)order.TimeOfOrder,
                Total = order.Total
            };
        }

        public Product DbModelToBusinessModel(Products product)
        {
            return new Product { ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price
            };
        }

        public Products BusinessModelToDbModel(Product product)
        {
            return new Products
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price
            };
        }

        public StoreLocation DbModelToBusinessModel(StoreLocations Store)
        {
            return new StoreLocation { Name = Store.Name,
                StoreLocationId = Store.StoreLocationId,
                Address1 = Store.Address1,
                Address2 = Store.Address2,
                City = Store.City,
                State = Store.State,
                Zip = Store.Zip
            };
        }

        public StoreLocations BusinessModelToDbModel(StoreLocation Store)
        {
            return new StoreLocations
            {
                Name = Store.Name,
                StoreLocationId = Store.StoreLocationId,
                Address1 = Store.Address1,
                Address2 = Store.Address2,
                City = Store.City,
                State = Store.State,
                Zip = Store.Zip
            };
        }

    }
}