namespace Data;

public interface ICalculatePriceStrategy
{
    public double CalculatePrice(List<MovieTicket> tickets, bool isStudentOrder);
}