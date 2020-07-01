using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Test
{
    public class CustomerTest
    {
        Customer customer = new Customer();
        [Fact]
        public void CustomerInfoisValid()
        {
            

            string someData = "someData";
            string someEmail = "email@test.com";

            customer.FirstName = someData;
            customer.LastName = someData;
            customer.Email = someEmail;
            
            Assert.Equal(someData, customer.FirstName);
            Assert.Equal(someData, customer.LastName);
            Assert.Equal(someEmail, customer.Email);

        }
         
        [Fact]
        public void CustomerInfoThrowsExceptionIfNull()
        {
            Assert.ThrowsAny<ArgumentException>(() => customer.FirstName = "");
            Assert.ThrowsAny<ArgumentException>(() => customer.LastName = "");
            Assert.ThrowsAny<ArgumentException>(() => customer.Email = "");
        }

       
    }
}