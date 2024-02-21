namespace Data.OrderState
{
    public interface IOrderState
    {
        public void Cancel();

        public void Change();

        public void SendTickets();

        public void CheckPayment(bool paid);

        public void Submit();
    }
}