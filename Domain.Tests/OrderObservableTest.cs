using Data;
using Data.OrderState;
using Moq;

namespace Test;

public class OrderObservableTest
{
    
    [Test]
    public void Submit()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderState = new OrderCreatedState(orderContext.Object);

        // Act
        orderState.Submit();
        // Assert
        orderContext.Verify(context => context.Notify(), Times.Once);
    }

    [Test]
    public void Reminder()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderState = new OrderProvisionedState(orderContext.Object);

        // Act
        orderState.CheckPayment(false);
        // Assert
        orderContext.Verify(context => context.Notify(), Times.Once);
    }

    [Test]
    public void Cancelled()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderState = new OrderProvisionedState(orderContext.Object);

        // Act
        orderState.Cancel();
        // Assert
        orderContext.Verify(context => context.Notify(), Times.Once);
    }

    [Test]
    public void Paid()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderState = new OrderProvisionedState(orderContext.Object);

        // Act
        orderState.CheckPayment(true);
        // Assert
        orderContext.Verify(context => context.Notify(), Times.Once);
    }
}