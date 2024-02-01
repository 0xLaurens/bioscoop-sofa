using Data;

namespace Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculatePrice_SecondTicketShouldBeFreeForStudentsInTheWeekend()
    {
        // arrange
        const bool studentPricing = true;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 3));
        });
    }

    [Test]
    public void CalculatePrice_SecondTicketShouldBeFreeForStudentsDuringWeekdays()
    {
        // arrange
        const bool studentPricing = true;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 01); // Thursday February 1st

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        MovieTicket movieTicket6 = new(movieScreening, premiumTickets, 1, 6); // free 
        MovieTicket movieTicket7 = new(movieScreening, premiumTickets, 1, 7); // 10 
        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);
        order.AddSeatReservation(movieTicket6);
        order.AddSeatReservation(movieTicket7);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(false));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 4));
        });
    }
   
    [Test]
    public void CalculatePrice_SecondTicketShouldBeFreeForRegularVisitorsDuringWeekdays()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 01); // Thursday February 1st

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(false));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 3));
        });
    }

    [Test]
    public void CalculatePrice_OrderInWeekendShouldGiveGroupDiscountIfMoreThan6()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // 10 
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // 10 
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        MovieTicket movieTicket6 = new(movieScreening, premiumTickets, 1, 6); // 10

        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);
        order.AddSeatReservation(movieTicket6);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 6 * 0.9));
        });
    }

    [Test]
    public void CalculatePrice_OrderInWeekendFullPriceIfLessThan6()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // 10 
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // 10 
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10

        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 5));
        });
    }

    [Test]
    public void CalculatePrice_PremiumTicketShouldAdd2EuroToStudentOrder()
    {
        // arrange
        const bool studentPricing = true;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 2        

        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 2));
        });
    }


    [Test]
    public void CalculatePrice_PremiumTicketShouldAdd3EuroToRegularOrder()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 3

        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 3));
        });
    }


    [Test]
    public void CalculatePrice_PremiumTicketNoIncreasedFeesForFreeSecondTicket()
    {
        // arrange
        const bool studentPricing = true;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);

        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 2
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10 + 2
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free 
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10 + 2

        Order order = new(1, studentPricing);

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo((pricePerSeat + 2) * 3));
        });
    }
}