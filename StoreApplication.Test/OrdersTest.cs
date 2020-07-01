using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Test
{

    public class OrdersTest
    {
        private readonly Order order = new Order();
        [Fact]
        public void OrderIdShouldDefaultToZero()
        {
            Assert.Equal(0, order.OrderId);
        }
        [Fact]
        public void OrderDateShouldDefaultToNull()
        {
            Assert.Null(order.TimeOfOrder);
        }
        
       
        [Fact]
        public void TotalCostThrowsExceptionWhenOrderLineIsEmpty()
        {
            Assert.ThrowsAny<Exception>(() => order.Total);
        }
    }

}