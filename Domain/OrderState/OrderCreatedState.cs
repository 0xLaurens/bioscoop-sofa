using Data.Observers;

namespace Data.OrderState
{
    public class OrderCreatedState : IOrderState
    {
        private readonly IOrderContext _context;
        private readonly IPublisher _publisher;

        public OrderCreatedState(IOrderContext context, IPublisher publisher)
        {
            _publisher = publisher; 
            _context = context;
        }

        public void Cancel() => throw new InvalidOperationException("Cannot cancel, order not reserved yet");

        public void Change() => throw new InvalidOperationException("Cannot change, not submitted");


        public void CheckPayment(bool paid) => throw new InvalidOperationException("Cannot check payment, not submitted");


        public void Submit()
        {
            _publisher.Notify();
            _context.SetState(new OrderReservedState(_context, _publisher));  
        } 
        

        public void SendTickets() => throw new InvalidOperationException("Order cancelled, cannot submit");
        
    }
}
