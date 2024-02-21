﻿namespace Data.OrderState
{
    public class OrderReservedState : IOrderState
    {
        private readonly IOrderContext _context;

        public OrderReservedState(IOrderContext context)
        {
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
                _context.Notify();
                _context.SetState(new OrderPaidState(_context));
                return;
            }
            
            _context.SetState(new OrderProvisionedState(_context));
        } 




        public void Submit() => throw new InvalidOperationException("Order reserved, cannot submit");

        public void SendTickets() => throw new InvalidOperationException("Order reserved, cannot send tickets unless order is paid");
       
    }
}
