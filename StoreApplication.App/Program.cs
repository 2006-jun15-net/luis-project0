using System;
using StoreApplication.Library;

namespace StoreApplication.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer luis = new Customer("Luis", "Gomez");
            Console.WriteLine(luis);
            Console.WriteLine(luis.CustomerID);
            Console.WriteLine(luis.FirstName);
            Console.WriteLine(luis.OrderHistory);


        }
    }
}
