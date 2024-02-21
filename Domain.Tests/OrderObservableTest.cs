using Data;
using Data.Observers;
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
        var orderPublisher = new Mock<IPublisher>();
        var orderState = new OrderCreatedState(orderContext.Object, orderPublisher.Object);

        // Act
        orderState.Submit();
        // Assert
        orderPublisher.Verify(pub => pub.Notify(), Times.Once);
    }

    [Test]
    public void Reminder()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderPublisher = new Mock<IPublisher>();
        var orderState = new OrderProvisionedState(orderContext.Object, orderPublisher.Object);

        // Act
        orderState.CheckPayment(false);
        // Assert
        orderPublisher.Verify(pub => pub.Notify(), Times.Once);
    }

    [Test]
    public void Cancelled()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderPublisher = new Mock<IPublisher>();
        var orderState = new OrderProvisionedState(orderContext.Object, orderPublisher.Object);

        // Act
        orderState.Cancel();
        // Assert
        orderPublisher.Verify(pub => pub.Notify(), Times.Once);
    }

    [Test]
    public void Paid()
    {
        // Arrange
        var orderContext = new Mock<IOrderContext>();
        var orderPublisher = new Mock<IPublisher>();
        var orderState = new OrderProvisionedState(orderContext.Object, orderPublisher.Object);

        // Act
        orderState.CheckPayment(true);
        // Assert
        orderPublisher.Verify(pub => pub.Notify(), Times.Once);
    }
}