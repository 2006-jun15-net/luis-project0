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
            //arrange

            string randomValue = "RandomValue";
            //act
            customer.FirstName = randomValue;
            customer.LastName = randomValue;
            customer.Email = randomValue;


            //assert
            Assert.Equal(randomValue, customer.FirstName);
            Assert.Equal(randomValue, customer.LastName);
            Assert.Equal(randomValue, customer.Email);

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