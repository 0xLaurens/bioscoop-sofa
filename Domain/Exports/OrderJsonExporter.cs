using System.Text.Json.Nodes;
using DocentoScoop.Domain.Models;

namespace Data.Exports
{
    public class OrderJsonExporter : IOrderExporter
    {
        public void Export(Order order)
        {
            JsonObject jsonOrder = new JsonObject
            {
                { "orderNr", order.GetOrderNr() },
                { "isStudentOrder", order.IsStudentOrder() },
                { "totalPrice", order.CalculatePrice() }
            };

            JsonArray jsonTickets = new JsonArray();
            foreach (MovieTicket ticket in order.GetTickets())
            {
                JsonObject jsonTicket = new JsonObject
                {
                    { "screeningDate", ticket.GetScreeningDate() },
                    { "isPremiumTicket", ticket.IsPremiumTicket() },
                    { "price", ticket.GetPrice() },
                };
                jsonTickets.Add(jsonTicket);
            }
            jsonOrder.Add("tickets", jsonTickets);

            Console.WriteLine(jsonOrder.ToString());

      
        }

        public OrderExportFormat Supports() => OrderExportFormat.JSON;
    }
}