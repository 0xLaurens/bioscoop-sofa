using Data.Observers;

namespace Data.OrderState
{
    public class OrderPaidState : IOrderState
    {
        private readonly IOrderContext _context;
        private readonly IPublisher _publisher;

        public OrderPaidState(IOrderContext context, IPublisher publisher)
        {
            _publisher = publisher;
            _context = context;
        }

        public void Cancel() => throw new InvalidOperationException("Order paid, cannot cancel");


        public void Change() => throw new InvalidOperationException("Order paid, cannot change");


        public void CheckPayment(bool paid) => throw new InvalidOperationException("Order paid, cannot process payment");
  

        public void SendTickets()
        {
            // Send some tickets and then...
            _context.SetState(new OrderProcessedState());
        }


        public void Submit() => throw new InvalidOperationException("Order paid, cannot submit");
    
    }
}
