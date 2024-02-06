namespace Data;

public interface ICalculatePriceStrategy
{
    public decimal CalculatePrice(List<MovieTicket> tickets, bool isStudentOrder);
}