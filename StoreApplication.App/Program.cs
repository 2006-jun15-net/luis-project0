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

        static void Main(string[] args)
        {
            StoreController sc = new StoreController();
            OrderController oc = new OrderController();
            ProductController pc = new ProductController();
            CustomerController cc = new CustomerController();

            cc.DisplayCustomers();
            

            

        }
        
        
    }
}