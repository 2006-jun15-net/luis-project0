using StoreApplication.DatabaseAccess.Model;
using StoreApplication.Library;
using System;
using System.Linq;

namespace StoreApplication.DatabaseAccess.Controllers
{
    
    public class CustomerController
    {
        
        public readonly IRepository<Customers> repository = null;

        
        public CustomerController()
        {
            repository = new GeneralRepository<Customers>();
        }
        public CustomerController(IRepository<Customers> repo)
        {
            repository = repo;
        }

        
        public void DisplayCustomers()
        {
            Console.WriteLine("List of Customers:");
            foreach (var c in repository.GetAll().ToList())
            {
                Console.WriteLine($" ID: {c.CustomerId} Name: {c.FirstName} {c.LastName} Email: {c.Email} \n");
            }
        }


        public Customers SearchCustomerByName(string FirstName, string LastName)
        {
            if (repository.GetAll().Any(c => c.FirstName.Equals(FirstName)) && repository.GetAll().Any(c => c.LastName.Equals(LastName)))
            {
                Customers customer = repository.GetAll().First(c => c.FirstName.Equals(FirstName) && c.LastName.Equals(LastName));
                Console.WriteLine($" Customer ID: {customer.CustomerId} Name: {customer.FirstName} {customer.LastName}");
                return customer;
            }
            else
            {
                Console.WriteLine($"There are no customers by that name");
                return null;
            }
             
        }

       

    }


}