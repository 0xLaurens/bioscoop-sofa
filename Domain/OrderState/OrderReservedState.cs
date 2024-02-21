using Data.Observers;

namespace Data.OrderState
{
    public class OrderReservedState : IOrderState
    {
        private readonly IOrderContext _context;
        private readonly IPublisher _publisher;

        public OrderReservedState(IOrderContext context, IPublisher publisher)
        {
            _publisher = publisher;
            _context = context;
        }

        public void Cancel() => _context.SetState(new OrderCancelledState());


        public void Change()
        {
            // Change order, maybe calculate a new price
            // we could set a new state, but we're already in this state so 🤷‍
        }


        public void CheckPayment(bool paid)
        {
            if (paid)
            {
                _publisher.Notify();
                _context.SetState(new OrderPaidState(_context, _publisher));
                return;
            }
            
            _context.SetState(new OrderProvisionedState(_context, _publisher));
        } 




        public void Submit() => throw new InvalidOperationException("Order reserved, cannot submit");

        public void SendTickets() => throw new InvalidOperationException("Order reserved, cannot send tickets unless order is paid");
       
    }
}
