using Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Test;

public class OrderCreatedStateTest
{
    
    [Test]
    public void OrderCreatedStateTest_CheckPrice()
    {
     
     
        
        
        

        // Act
        var mockOrder = new Mock<Order>();
        mockOrder.Setup(x => x.CalculatePrice()).Returns(10.0);
        
        var orderState = new OrderCreatedState(mockOrder.Object);
        
        // Assert
        Assert.That(orderState.CheckPrice() == 10.0);
        
        
    }
    
    [Test]
    public void OrderCreatedState_Cancel()
    {
        // Arrange
        Order order = new Order(1, true);
     
        var orderState = new OrderCreatedState(order);

        // Act
        orderState.Cancel();
        

        // Assert
        Assert.That(order.getIOrderState().GetType() == typeof(OrderCancelledState));
        //Assert.Throws<InvalidOperationException>(orderState.Cancel);
    }
    
    [Test]
    public void OrderCreatedState_Psy()
    {
        // Arrange
        Order order = new Order(1, true);
     
        var orderState = new OrderCreatedState(order);

        // Act
        orderState.Pay();
        

        // Assert
        Assert.That(order.getIOrderState().GetType() == typeof(OrderDoneState));
        //Assert.Throws<InvalidOperationException>(orderState.Cancel);
    }
}