using DocentoScoop.Domain.Models;

namespace Data.Rules
{
    public interface ITicketPriceRule
    {
        public decimal CalculateNewPrice(decimal currentPrice, int ticketOrder, MovieTicket ticket, Order order);

        
    }
}
