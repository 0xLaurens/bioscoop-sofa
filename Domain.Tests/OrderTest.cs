using Data;

namespace Test;

public partial class Tests
{
    // The second ticket purchased by a student should be free of charge.
    // 1. Order must be placed by a student
    // 2. Day of the week should not matter
    [Test]
    public void CalculatePrice_ShouldThrowExceptionIfNoStrategyIsSet()
    {
        // // arrange
        // const bool studentPricing = true;
        // const bool premiumTickets = false;
        // const int pricePerSeat = 10;
        // var date = new DateTime(2024, 02, 01); // Thursday February 1st
        //
        // Movie movie = new("Terminator 2");
        // MovieScreening movieScreening = new(date, pricePerSeat, movie);
        // MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        // MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        // MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        // MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free
        // MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        // MovieTicket movieTicket6 = new(movieScreening, premiumTickets, 1, 6); // free 
        // MovieTicket movieTicket7 = new(movieScreening, premiumTickets, 1, 7); // 10 
        // Order order = new(1, studentPricing);
        //
        //
        // // act
        //
    }
}