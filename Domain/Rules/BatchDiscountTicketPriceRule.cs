using DocentoScoop.Domain.Models;

namespace Data.Rules
{
    /// <summary>
    /// On weekends, non-students pay full price unless the order consists of 6 or more tickets
    /// </summary>
    public class BatchDiscountTicketPriceRule : ITicketPriceRule
    {
        private const decimal BATCH_DISCOUNT = 0.9M;
        private const int BATCH_LOWER_BOUNDARY = 6;

        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            return ticket.IsWeekendScreening() && !order.IsStudentOrder() && order.GetTicketCount() >= BATCH_LOWER_BOUNDARY ? currentPrice * BATCH_DISCOUNT : currentPrice;
        }
    }
}
