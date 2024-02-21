namespace Data.OrderState
{
    public class OrderProcessedState : IOrderState
    {
        public void Cancel() => throw new InvalidOperationException("Order is processed, your operation is futile");

        public void Change() => throw new InvalidOperationException("Order is processed, your operation is futile");

        public void CheckPayment(bool paid) => throw new InvalidOperationException("Order is processed, your operation is futile");

        public void SendTickets() => throw new InvalidOperationException("Order is processed, your operation is futile");

        public void Submit() => throw new InvalidOperationException("Order is processed, your operation is futile");
    }
}
