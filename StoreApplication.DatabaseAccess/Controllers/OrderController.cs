using Microsoft.EntityFrameworkCore;
using StoreApplication.DatabaseAccess.Model;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.DatabaseAccess.Controllers
{
    
    public class OrderController
    {
        
        public readonly IRepository<Orders> repository = null;

        
        public OrderController()
        {
            repository = new GeneralRepository<Orders>();
        }
        public OrderController(IRepository<Orders> repo)
        {
            repository = repo;
        }

        
        public void DisplayOrders()
        {
            Console.WriteLine("List of Orders:");
            foreach (var order in repository.GetAll().ToList())
            {
                Console.WriteLine($"Order ID: {order.OrderId} Total Cost: {order.Total}\n" +
                    $"Placed by customer with ID: {order.CustomerId} On: {order.TimeOfOrder} At Store with ID: {order.LocationId}\n");
            }
        }

        
        public void DisplayOrderDetails(int orderId)
        {
            if (repository.GetAll().Any(o => o.OrderId == orderId))
            {
                var context = new storeapplicationContext(GeneralRepository<Orders>.Options);
                var order = context.Orders
                    .Include(o => o.OrderLines)
                        .ThenInclude(ol => ol.Product)
                    .First(o => o.OrderId == orderId);
                Console.WriteLine($"Order ID: {order.OrderId} Total Cost: {order.Total}\n" +
                    $"Placed by customer with ID: {order.CustomerId} On: {order.TimeOfOrder} At Store with ID: {order.LocationId}\n");
                foreach (var ol in order.OrderLines)
                {
                    Console.WriteLine($"Product: {ol.Product.Name}\nPrice: {ol.Product.Price}\nQty: {ol.Amount}\n");
                }
                context.Dispose();
            }
            else
            {
                Console.WriteLine($"No orders with ID: {orderId}");
            }

        }

        
        public void DisplayOrderDetailsOfStore(int storeId)
        {
            if (repository.GetAll().Any(o => o.LocationId == storeId))
            {
                List<Orders> orders = repository.GetAll().Where(o => o.LocationId == storeId).ToList();
                foreach (var order in orders)
                {
                    DisplayOrderDetails(order.OrderId);
                }
            }
            else
            {
                Console.WriteLine($"No orders placed at store with ID: {storeId}");
            }

        }

       
        public void DisplayOrderDetailsOfCustomer(int customerId)
        {
            if (repository.GetAll().Any(o => o.CustomerId == customerId))
            {
                List<Orders> orders = repository.GetAll().Where(o => o.CustomerId == customerId).ToList();
                foreach (var order in orders)
                {
                    DisplayOrderDetails(order.OrderId);
                }
            }
            else
            {
                Console.WriteLine($"No orders for customer with ID: {customerId}");
            }
        }

    }



}