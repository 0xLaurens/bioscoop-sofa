using System.Text.Json;

namespace Data;

public class Order(int orderNr, bool isStudentOrder)
{
    private int OrderNr { get; } = orderNr;
    private bool IsStudentOrder { get; } = isStudentOrder;
    
    private List<MovieTicket> MovieTickets { get; } = [];

    public int GetOrderNr()
    {
        return OrderNr;
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        MovieTickets.Add(movieTicket);
    }

    public double CalculatePrice()
    {
        double totalPrice = 0.0;

        for (int i = 0; i < MovieTickets.Count; i++)
        {
            MovieTicket ticket = MovieTickets[i];
            double basePrice = ticket.GetPrice();

            // For students the second ticket is free. 
            // ex.
            // 0 % 2 = 0 -> not free 
            // 1 % 2 = 1 -> free
            // 2 % 2 = 0 -> not free
            // etc.
            if (IsStudentOrder && i % 2 == 1)
            {
                continue;
            }

            // Throughout the week the second ticket is free
            // Weekend is defined as (Saturday and Sunday) despite in the text it defining the weekend
            // as (monday/tuesday/wednesday/thursday) 
            if (!ticket.GetScreening().IsWeekend() && i % 2 == 1)
            {
                continue;
            }

            // Premium tickets are more expensive
            // 2 euro price increase for students
            // 3 euro for non-students
            if (ticket.IsPremiumTicket())
            {
                basePrice += IsStudentOrder ? 2 : 3;
            }

            // Weekend group discount price if group size larger than 6    
            // 10% price reduction  
            if (ticket.GetScreening().IsWeekend() && MovieTickets.Count >= 6)
            {
                basePrice *= 0.9;
            }

            totalPrice += basePrice;
        }

        return totalPrice;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        switch (exportFormat)
        {
            case TicketExportFormat.Plaintext:
                ExportToPlaintext();
                break;
            case TicketExportFormat.Json:
                ExportToJson();
                break;
            default:
                Console.WriteLine("Invalid export format");
                throw new ArgumentOutOfRangeException(nameof(exportFormat), exportFormat, null);
        }
    }

    private void ExportToPlaintext()
    {
        var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var outputFile = new StreamWriter(Path.Combine(docPath, "tickets.txt"));
        
        foreach (var ticket in MovieTickets)
        {
            outputFile.WriteLine(ticket.ToString());
        }
        
        outputFile.Close();
    }

    private void ExportToJson()
    {
        var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var outputFile = new StreamWriter(Path.Combine(docPath, "tickets.json"));
        var ticketsJson = JsonSerializer.Serialize(MovieTickets);
        
        outputFile.WriteLine(ticketsJson);
        outputFile.Close();
    }
}