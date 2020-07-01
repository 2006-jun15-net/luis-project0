using StoreApplication.DatabaseAccess.Model;
using StoreApplication.Library;
using System;
using System.Linq;

namespace StoreApplication.DatabaseAccess.Controllers
{
    
    public class ProductController
    {
       
        public readonly IRepository<Products> repository = null;

        
        public ProductController()
        {
            repository = new GeneralRepository<Products>();
        }
        public ProductController(IRepository<Products> repo)
        {
            repository = repo;
        }

        
        public void DisplayProducts()
        {
            Console.WriteLine("List of Products:\n");
            foreach (var p in repository.GetAll().ToList())
            {
                Console.WriteLine($"Product Name: {p.Name} ID: {p.ProductId}\n");
            }
        }
    }
}