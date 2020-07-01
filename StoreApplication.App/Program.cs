using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using StoreApplication.DatabaseAccess.Model;
using StoreApplication.DatabaseAccess.Controllers;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.App
{
    public class Program
    {

        
        private static void PlaceOrder(Customers currentCustomer, StoreController storeControl, ProductController productControl, OrderController orderControl)
        {
            Console.WriteLine("Please choose the store that you would like to place an order with ");
            storeControl.DisplayStores();
            Console.WriteLine("Enter the store ID: ");
            string userInput = Console.ReadLine();
            int storeId;
            while (!int.TryParse(userInput, out storeId))
            {
                Console.WriteLine("Please select a valid Store ID.");
                userInput = Console.ReadLine();
            }

            if (storeControl.repository.GetAll().Any(s => s.StoreLocationId == storeId))
            {
                var currentStore = storeControl.repository.GetById(storeId);
               
                using var context = new storeapplicationContext(GeneralRepository<StoreLocations>.Options);
                var inventory = context.Inventory
                    .Include(i => i.Product)
                    .Where(i => i.LocationId == storeId)
                    .ToList();
                
                Dictionary<Products, int> cartProducts = new Dictionary<Products, int>();
                
                while(true)
                {
                    Console.WriteLine("Please select an item to add to your order:");
                    foreach (var item in inventory)
                    {
                        Console.WriteLine($" {item.Product.ProductId}  {item.Product.Name}  ${item.Product.Price.ToString("0.##")}  Amount in stock: {item.Quantity}\n");
                    }
                    Console.WriteLine("Please enter a product ID to add item to your order or please type 0 to exit and complete your order");
                    userInput = Console.ReadLine();
                    int productId;
                    while (!int.TryParse(userInput, out productId))
                    {
                        Console.WriteLine("Please respond with a valid ID.");
                        userInput = Console.ReadLine();
                    }

                    if (cartProducts != null)
                    {
                        while (cartProducts.Keys.Any(p => p.ProductId == productId))
                        {
                            Console.WriteLine("Item was already added to order.");
                            foreach (var item in inventory)
                            {
                                Console.WriteLine($"ID: {item.Product.ProductId} Product Name: {item.Product.Name} Price: ${item.Product.Price}  Amount in stock: {item.Quantity}\n");
                            }
                            Console.WriteLine("Enter a product ID to add item to your order( or please type 0 to exit the order):");
                            userInput = Console.ReadLine();
                            while (!int.TryParse(userInput, out productId))
                            {
                                Console.WriteLine("Please enter a valid product ID.");
                                Console.WriteLine("Enter a product ID to add item to your order( or please type 0 to exit the order):");
                                userInput = Console.ReadLine();
                            }
                        }
                    }
                    
                    
                    if(productId == 0) { break; }

                    
                    if (inventory.Any(i => i.Product.ProductId == productId))
                    {
                        
                        var p = productControl.repository.GetById(productId);
                        Console.WriteLine($"How many {p.Name}s do you want to add to the order:");
                        userInput = Console.ReadLine();
                        int qty;
                        while (!int.TryParse(userInput, out qty))
                        {
                            Console.WriteLine("Please put in a valid amount.");
                            Console.WriteLine($"How many {p.Name}s do you want to add to the order:");
                            userInput = Console.ReadLine();
                        }
                        if (qty > 0)
                        {
                            
                            Inventory inventoryLine = inventory.First(i => i.Product.ProductId == productId);
                            if(inventoryLine.Quantity == 0)
                            {
                                Console.WriteLine($"{p.Name} no longer in stock.");
                               
                            }
                            else if(inventoryLine.Quantity < qty)
                            {
                                Console.WriteLine("You can't order more products than are available.");
                            }
                            else
                            {
                                cartProducts.Add(p, qty);
                                inventoryLine.Quantity -= qty;
                                context.Update(inventoryLine);
                                context.SaveChanges();
                                Console.WriteLine("Product added to order!");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Quantity must be positive.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Unfortunately product number {productId} is not available in this store.");
                    }

                }
                if(cartProducts.Count == 0)
                {
                    Console.WriteLine("No products were added to order.");
                }
                else
                {
                    decimal totalCostOfOrder = 0;
                    foreach (var item in cartProducts.Keys)
                    {
                        totalCostOfOrder += (item.Price * cartProducts[item]);
                    }
                    Console.WriteLine("Your total comes out to $" + totalCostOfOrder.ToString("0.##"));

                    
                    Orders newOrder = new Orders { 
                        CustomerId = currentCustomer.CustomerId, 
                        LocationId = currentStore.StoreLocationId,  
                        Total = totalCostOfOrder,
                        TimeOfOrder = DateTime.Now};
                    orderControl.repository.Add(newOrder);
                    orderControl.repository.Save();

                    newOrder = orderControl.repository.GetAll().First(o => o.CustomerId.Equals(currentCustomer.CustomerId));

                    foreach (var item in cartProducts.Keys)
                    {
                        var product = context.Products
                            .Include(p => p.OrderLines)
                            .First(p => p.ProductId == item.ProductId);
                        product.OrderLines.Add(new OrderLines { OrderId = newOrder.OrderId, Order = newOrder, Amount = cartProducts[item] });
                    }

                    context.SaveChanges();

                    
                }
                

            }
            else
            {
                Console.WriteLine($"A store does not exist with that ID. Please use a valid store ID.");
            }

        }

        
        private static Customers CreateCustomer(CustomerController customerControl)
        {
            Customers customer = new Customers();
            Console.WriteLine("Please type 1 to create an account, or type 2 to use existing account");
            string userInput = Console.ReadLine();
            int input;
            while (!int.TryParse(userInput, out input))
            {
                Console.WriteLine("Invalid input. Not a number.");
                userInput = Console.ReadLine();
            }

            if (input == 1)
            {
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter an Email:");
                string email = Console.ReadLine();
                if (customerControl.repository.GetAll().Any(c => c.Email == email))
                {
                    Console.WriteLine($"The email {email} already exists in our database.");
                }
                else
                {
                    Customers newCustomer = new Customers { FirstName = firstName, LastName = lastName, Email = email };
                    customerControl.repository.Add(newCustomer);
                    customerControl.repository.Save();
                    customer = customerControl.repository.GetById(customerControl.repository.GetAll().First(c => c.Email == email).CustomerId);
                    Console.WriteLine($"Congratulations!! Your account was successfully registered. The email registered with us is {email} , and your ID is {customer.CustomerId}");
                }

            }
            else if (input == 2)
            {
                if (customerControl.repository.GetAll().FirstOrDefault() == null)
                {
                    Console.WriteLine("There are no customers.");
                }
                else
                {
                    customerControl.DisplayCustomers();
                    Console.WriteLine("Enter customer ID to begin: ");
                    userInput = Console.ReadLine();
                    int customerId;
                    while (!int.TryParse(userInput, out customerId))
                    {
                        Console.WriteLine("Please select a Valid Customer ID.");
                        userInput = Console.ReadLine();
                    }
                    if(customerControl.repository.GetAll().Any(customer => customer.CustomerId == customerId))
                    {
                        customer = customerControl.repository.GetById(customerId);
                    }
                    else
                    {
                        Console.WriteLine($"Customer number {customerId} does not exist.");
                        customer = null;
                    }
                    
                   
                }
            }
            else
            {
                Console.WriteLine("If the customer already exists type 2 to sign in as existing customer");
            }
            return customer;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello and Welcome to Gomez and Company!");
            string displayHome =
                "How could we assist you today?\n" +
                "1: Create new customer or choose customer to begin order\n" +
                "2. Place an order\n" +
                "3. Search for customer by Name\n" +
                "4: Display details of an order\n" +
                "5: Display order history of this customer\n" +
                "6: Display order history of a store\n" +
                "0: Exit";

            CustomerController customerControl = new CustomerController();
            OrderController orderControl = new OrderController();
            ProductController productControl = new ProductController();
            StoreController storeControl = new StoreController();
            Customers newCustomer = null;
            bool loggedIn = true;


            while (loggedIn == true)
            {
                Console.WriteLine(displayHome);
                Console.WriteLine("Please select your option or select 0 to exit");
                string userInput = Console.ReadLine();
                int input;
                while (!int.TryParse(userInput, out input))
                {
                    Console.WriteLine("Please select a valid option.");
                    userInput = Console.ReadLine();
                }

                switch (input)
                {
                    case 1:
                        newCustomer = CreateCustomer(customerControl);
                        break;

                    case 2:
                        if (newCustomer == null)
                        {
                            Console.WriteLine("Select and existing account or create a new user to continue.");
                        }
                        else
                        {
                            PlaceOrder(newCustomer, storeControl, productControl, orderControl);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name of the customer");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the customer");
                        string lastName = Console.ReadLine();
                        customerControl.SearchCustomerByName(firstName, lastName);
                        break;
                    
                    case 4:
                        Console.WriteLine("Please select the order for which you would like to see the details!");
                        orderControl.DisplayOrders();
                        Console.WriteLine("Please enter a valid Order ID ");
                        userInput = Console.ReadLine();
                        int orderId;
                        while (!int.TryParse(userInput, out orderId))
                        {
                            Console.WriteLine("Please select a valid order ID.");
                            userInput = Console.ReadLine();
                        }
                        orderControl.DisplayOrderDetails(orderId);
                        break;
                    case 5:
                        if (newCustomer == null)
                        {
                            Console.WriteLine("Please select a customer to view order history.");
                        }
                        else
                        {
                            Console.WriteLine($" {newCustomer.FirstName} {newCustomer.LastName}:");
                            orderControl.DisplayOrderDetailsOfCustomer(newCustomer.CustomerId);
                        }
                        break;
                    case 6:
                        Console.WriteLine("For which store would you like to see their order history?");
                        storeControl.DisplayStores();
                        Console.WriteLine("Please enter a store ID to see it's order history:");
                        userInput = Console.ReadLine();
                        int storeId;
                        while (!int.TryParse(userInput, out storeId))
                        {
                            Console.WriteLine("Please select a valid store ID.");
                            userInput = Console.ReadLine();
                        }
                        if (storeControl.repository.GetAll().Any(s => s.StoreLocationId == storeId))
                        {
                            Console.WriteLine($" {storeControl.repository.GetById(storeId).Name}");
                            orderControl.DisplayOrderDetailsOfStore(storeId);
                        }
                        else
                        {
                            Console.WriteLine($"Sorry but there is no store with that ID.");
                        }

                        break;
                    case 0:
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option or 0 to exit.");
                        break;
                }
            }

        }
    }
}