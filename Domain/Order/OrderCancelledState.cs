namespace Data;

public class OrderCancelledState : IOrderState
{
   



    public void Pay()
    {
        throw new InvalidOperationException("The order was cancelled");
    }

    public void Cancel()
    {
        throw new InvalidOperationException("The order was cancelled");
    }

    public double CheckPrice()
    {
        throw new InvalidOperationException("The order was cancelled");
    }
}