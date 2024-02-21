using System.Text;
using DocentoScoop.Domain.Models;

namespace Data.Exports
{
    public class OrderPlainTextExporter : IOrderExporter
    {
        public void Export(Order order)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order: {order.GetOrderNr()} | Price: {order.CalculatePrice():C2}");
            foreach (MovieTicket ticket in order.GetTickets())
                sb.AppendLine(ticket.ToString());

            Console.WriteLine(sb.ToString());
        }

        public OrderExportFormat Supports() => OrderExportFormat.PLAINTEXT;
    }
}