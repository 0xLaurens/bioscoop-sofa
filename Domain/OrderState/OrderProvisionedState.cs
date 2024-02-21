using Data.Observers;

namespace Data.OrderState
{
    public class OrderProvisionedState : IOrderState
    {
        private readonly IOrderContext _context;
        private readonly IPublisher _publisher;


        public OrderProvisionedState(IOrderContext context, IPublisher publisher)
        {
            _publisher = publisher;
            _context = context;
        }

        public void Cancel()
        {
            _publisher.Notify();
            _context.SetState(new OrderCancelledState());
        } 

        public void Change() => throw new InvalidOperationException("Order provisioned, cannot change");

        public void CheckPayment(bool paid)
        {
            var hoursUntilScreening = _context.GetScreeningDate().Subtract(DateTime.Now).TotalHours;

            // Wat is DRY 
            if (paid)
            {
                _publisher.Notify();
                _context.SetState(new OrderPaidState(_context, _publisher));
            }
            else if (hoursUntilScreening is < 24 and > 12)
            {
                _publisher.Notify();
            }
            else 
            {
                _publisher.Notify();
                _context.SetState(new OrderCancelledState());
            }

            // else => do nothing, in the correct state
        }

        public void SendTickets() => throw new InvalidOperationException("Order provisioned, not paid yet");


        public void Submit() => throw new InvalidOperationException("Order provisioned, already submitted");
    }
}