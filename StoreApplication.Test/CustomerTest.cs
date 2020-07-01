using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Test
{
    public class CustomerTest
    {
        Customer customer = new Customer();
        [Fact]
        public void CustomerStoresNamesCorrectly()
        {
            

            string someData = "someData";
            customer.FirstName = someData;
            customer.LastName = someData;
            customer.Email = someData;


            
            Assert.Equal(someData, customer.FirstName);
            Assert.Equal(someData, customer.LastName);
            Assert.Equal(someData, customer.Email);

        }
         
        [Fact]
        public void NameThrowsExceptionIfNull()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.FirstName = "");
            Assert.ThrowsAny<ArgumentException>(() => customer.LastName = "");
            Assert.ThrowsAny<ArgumentException>(() => customer.Email = "");
        }

       
    }
}