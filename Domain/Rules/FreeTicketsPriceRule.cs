using DocentoScoop.Domain.Models;

namespace Data.Rules
{
    /// <summary>
    /// Every second ticket is free for students or on weekdays
    /// </summary>
    public class FreeTicketsPriceRule : ITicketPriceRule
    {
        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order)
        {
            return ((order.IsStudentOrder() || !ticket.IsWeekendScreening()) && ticketOrder % 2 == 0) ? decimal.Zero : currentPrice;
        }
    }
}
