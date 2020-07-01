using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Test
{
    public class StoreLocationTest
    {
        StoreLocation store = new StoreLocation();
        [Fact]
        public void StoreIdDefaultsToZero()
        {
            Assert.Equal(0, store.StoreLocationId);
        }

        [Fact]
        public void StoreNameIsEmptyThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => store.Name = "");
        }

        [Fact]
        public void StoreAddressInfoIsEmptyThrowsException()
        {
            Assert.ThrowsAny<ArgumentException>(() => store.Address1 = "");
            Assert.ThrowsAny<ArgumentException>(() => store.City = "");
            Assert.ThrowsAny<ArgumentException>(() => store.State = "");
            Assert.ThrowsAny<ArgumentException>(() => store.Zip = "");
        }


    }
}