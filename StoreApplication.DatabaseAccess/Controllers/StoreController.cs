using StoreApplication.DatabaseAccess.Model;
using StoreApplication.Library;
using System;
using System.Linq;

namespace StoreApplication.DatabaseAccess.Controllers
{
   
    public class StoreController
    {
        
        public readonly IRepository<StoreLocations> repository = null;

        
        public StoreController()
        {
            repository = new GeneralRepository<StoreLocations>();
        }
        public StoreController(IRepository<StoreLocations> repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Prints out a list of all the stores in the Stores table
        /// </summary>
        public void DisplayStores()
        {
            Console.WriteLine("List of Stores:\n");
            foreach (var s in repository.GetAll().ToList())
            {
                Console.WriteLine($"ID: {s.StoreLocationId} {s.Name} Address: {s.Address1} {s.City}, {s.State} {s.Zip}\n");
            }
        }
    }
}