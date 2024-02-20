namespace Data;

public class OrderDoneState : IOrderState
{
    private Order order;

    public OrderDoneState(Order order)
    {
        this.order = order;
    }


    public double CheckPrice()
    {
        return this.order.CalculatePrice();
    }

    public void Cancel()
    {
        throw new InvalidOperationException("Order was already completed");
    }

    public void Pay()
    {
        throw new InvalidOperationException("Order was already paid");
    }
    
    
}