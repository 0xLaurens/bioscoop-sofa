namespace Data;

public class OrderCreatedState
{
    
    private Order order;

    public OrderCreatedState(Order order)
    {
        this.order = order;
    }
    
    public double CheckPrice()
    {
        return this.order.CalculatePrice();
    }

    public void Cancel()
    {
        order.setIOrderState(new OrderCancelledState());
    }

    public void Pay()
    {
        order.setIOrderState(new OrderDoneState(order));
        
    }
}