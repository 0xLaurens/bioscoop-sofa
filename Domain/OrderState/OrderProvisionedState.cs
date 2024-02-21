namespace Data.OrderState
{
    public class OrderProvisionedState : IOrderState
    {
        private readonly IOrderContext _context;


        public OrderProvisionedState(IOrderContext context)
        {
            _context = context;
        }

        public void Cancel() => _context.SetState(new OrderCancelledState());

        public void Change() => throw new InvalidOperationException("Order provisioned, cannot change");

        public void CheckPayment(bool paid)
        {
            var hoursUntilScreening = _context.GetScreeningDate().Subtract(DateTime.Now).TotalHours;

            // Wat is DRY 
            if (paid)
            {
                _context.Notify();
                _context.SetState(new OrderPaidState(_context));
            }
            else if (hoursUntilScreening is < 24 and > 12)
            {
                _context.Notify();
            }
            else 
            {
                _context.Notify();
                _context.SetState(new OrderCancelledState());
            }

            // else => do nothing, in the correct state
        }

        public void SendTickets() => throw new InvalidOperationException("Order provisioned, not paid yet");


        public void Submit() => throw new InvalidOperationException("Order provisioned, already submitted");
    }
}