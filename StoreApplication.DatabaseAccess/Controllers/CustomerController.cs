using StoreApplication.DatabaseAccess.Model;
using StoreApplication.Library;
using System;
using System.Linq;

namespace StoreApplication.DatabaseAccess.Controllers
{
    
    public class CustomerController
    {
        
        public readonly IRepository<Customer> repository = null;

        
        public CustomerController()
        {
            repository = new GeneralRepository<Customer>();
        }
        public CustomerController(IRepository<Customer> repo)
        {
            repository = repo;
        }

        
        public void DisplayCustomers()
        {
            Console.WriteLine("List of Customers:");
            foreach (var c in repository.GetAll().ToList())
            {
                Console.WriteLine($"ID: {c.CustomerId} {c.FirstName} {c.LastName}\n");
            }
        }

        


    }


}