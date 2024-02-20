using Data;

namespace Test;

public class OrderCancelledStateTest
{
    [Test]
    public void OrderCancelledStateTest_CheckPrice()
    {
       
     
        var orderState = new OrderCancelledState();

        // Act

        // Assert
        //Assert.Throws<InvalidOperationException>(orderState.CheckPrice());
        Assert.Throws<InvalidOperationException>(() => { orderState.CheckPrice(); });
    }
    
    [Test]
    public void OrderCancelledStateTest_Cancel()
    {
       
     
        var orderState = new OrderCancelledState();

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(orderState.Cancel);
    }

    [Test]
    public void OrderCancelledStateTest_Pay()
    {
       
     
        var orderState = new OrderCancelledState();

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(orderState.Pay);
    }
}