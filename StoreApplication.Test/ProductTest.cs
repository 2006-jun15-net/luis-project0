using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Test
{
    public class ProductTest
    {
        Product product = new Product();

        [Fact]
        public void ProductNameCannotBeEmpty()
        {
            Assert.ThrowsAny<ArgumentException>(() => product.Name = "");
        }


        [Fact]
        public void ProductNameisValid()
        {
            string SomeName = "Name";

            product.Name = SomeName;

            Assert.Equal(SomeName, product.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void ProductPriceIsZeroOrNegativeThrowsException(decimal price)
        {
            Assert.ThrowsAny<ArgumentException>(() => product.Price = price);
        }

    }    
}
