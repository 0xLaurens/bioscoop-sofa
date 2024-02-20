using Data;

namespace Test;

public class OrderDoneStateTest
{
    [Test]
    public void OrderDoneStateTest_Cancel()
    {
        // Arrange
        Order order = new Order(1, true);
     
        var orderState = new OrderDoneState(order);

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(orderState.Cancel);
    }

    [Test]
    public void OrderDoneStateTest_Pay()
    {
        // Arrange
        Order order = new Order(1, true);
     
        var orderState = new OrderDoneState(order);

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(orderState.Pay);
    }
}