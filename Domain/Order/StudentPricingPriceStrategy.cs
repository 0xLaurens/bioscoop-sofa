namespace Data;

public class StudentPricingPriceStrategy: ICalculatePriceStrategy
{

    public decimal CalculatePrice(List<MovieTicket> tickets, bool isStudentOrder)
    {
        var totalPrice = 0.0m;
        for (var i = 0; i < tickets.Count; i++)
        {
            var ticket = tickets[i];
            var basePrice = ticket.GetPrice();

            if (isStudentOrder && i % 2 == 1)
            {
                continue;
            }
            
            
            if (!ticket.GetScreening().IsWeekend() && i % 2 == 1)
            {
                continue;
            }

            if (ticket.IsPremiumTicket())
            {
                basePrice += isStudentOrder ? 2 : 3;
            }

            if (ticket.GetScreening().IsWeekend() && tickets.Count >= 6)
            {
                basePrice *= 0.9m;
            } 
            
            totalPrice += basePrice;
        }

        return totalPrice;
    }
}