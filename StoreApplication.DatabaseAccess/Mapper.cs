using StoreApplication.DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Mapper
    {
        public Customer ModelToDbModel(Customers c)
        {
            return new Customer { FirstName = c.FirstName, LastName = c.LastName };
        }

        public Customers DbModelToModel(Customer c)
        {
            return new Customers { FirstName = c.FirstName, LastName = c.LastName };
        }


       
    }
}