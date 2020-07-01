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
        public void ProductNameIsEmptyThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => product.Name = "");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void ProductPriceIsZeroOrNegativeThrowsException(decimal price)
        {
            Assert.ThrowsAny<ArgumentException>(() => product.Price = price);
        }

        [Fact]
        public void ProductNameStoresCorrectly()
        {
            string randomName = "RandomName";

            product.Name = randomName;

            Assert.Equal(randomName, product.Name);
        }
        [Fact]
        public void ProductPriceStoresCorrectly()
        {
            decimal randomValue = 1.99M;

            product.Price = randomValue;

            Assert.Equal(randomValue, product.Price);
        }

        [Fact]
        public void ProductIdDefaultsToZero()
        {
            Assert.Equal(0, product.ProductId);
        }
    }
}
