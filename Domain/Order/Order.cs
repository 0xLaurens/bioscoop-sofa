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