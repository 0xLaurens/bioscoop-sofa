using Data;

namespace Test;

public partial class Tests
{
    // The second ticket purchased by a student should be free of charge.
    // 1. Order must be placed by a student
    // 2. Day of the week should not matter
    [Test]
    public void StudentPricingStrategy_SecondTicketShouldBeFreeForStudentsInTheWeekend()
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

        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);
        
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

    // The second ticket purchased by a student should be free of charge.
    // 1. Order must be placed by a student
    // 2. Day of the week should not matter
    [Test]
    public void StudentPricingStrategy_SecondTicketShouldBeFreeForStudentsDuringWeekdays()
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
        
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

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


    // The second purchased ticket should be free of charge for regular visitors during the weekdays
    // 1. The order must be placed by a non-student 
    // 2. The order must be placed on a regular day. 
    [Test]
    public void StudentPricingStrategy_SecondTicketShouldBeFreeForRegularVisitorsDuringWeekdays()
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
        
        
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

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

    // The second purchased ticket should be free of charge for regular visitors during the weekdays
    // 1. The order must be placed by a non-student 
    // 2. The order must be placed on a regular day. 
    [Test]
    public void StudentPricingStrategy_SecondTicketShouldBeNotBeFreeForRegularVisitorsDuringWeekends()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = false;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 03); // Saturday February 3rd 

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // 10
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // 10 
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10
        Order order = new(1, studentPricing);

        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);
        
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

    // The 10% group discount should only apply if
    // 1. The amount of users is greater than or equal 6  
    // 2. The order is placed during the weekend.
    [Test]
    public void StudentPricingStrategy_OrderInWeekendShouldGiveGroupDiscountIfGroupSizeIsEqualTo6People()
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
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

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

    // The 10% group discount should only apply if
    // 1. The amount of users is greater than or equal 6  
    // 2. The order is placed during the weekend.
    [Test]
    public void StudentPricingStrategy_OrderInWeekendShouldGiveGroupDiscountIfGroupSizeIsMoreThan6People()
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
        MovieTicket movieTicket7 = new(movieScreening, premiumTickets, 1, 7); // 10
        MovieTicket movieTicket8 = new(movieScreening, premiumTickets, 1, 8); // 10

        Order order = new(1, studentPricing);
        
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);
        

        // act
        order.AddSeatReservation(movieTicket1);
        order.AddSeatReservation(movieTicket2);
        order.AddSeatReservation(movieTicket3);
        order.AddSeatReservation(movieTicket4);
        order.AddSeatReservation(movieTicket5);
        order.AddSeatReservation(movieTicket6);
        order.AddSeatReservation(movieTicket7);
        order.AddSeatReservation(movieTicket8);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat * 8 * 0.9));
        });
    }


    // The 10% group discount should only apply if
    // 1. The amount of users is greater than or equal 6  
    // 2. The order is placed during the weekend.
    [Test]
    public void StudentPricingStrategy_OrderInWeekendShouldBeFullPriceIfGroupSizeLessThan6()
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
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

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

    // Premium tickets should increase the price of a ticket
    // 1. No matter what day of the week its placed
    // 2. It should increase the price by 2 euros instead of 3 if its a ticket purchased by a student.
    [Test]
    public void StudentPricingStrategy_PremiumTicketShouldAdd2EuroToStudentOrderDuringTheWeekend()
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
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 2));
        });
    }


    // Premium tickets should increase the price of a ticket
    // 1. No matter what day of the week its placed
    // 2. It should increase the price by 2 euros instead of 3 if its a ticket purchased by a student.
    [Test]
    public void StudentPricingStrategy_PremiumTicketShouldAdd2EuroToStudentOrderDuringRegularWeekdays()
    {
        // arrange
        const bool studentPricing = true;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 01); // Thursday February 1st.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 2        

        Order order = new(1, studentPricing);
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);
        

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(false));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 2));
        });
    }

    // Premium tickets should increase the price of a ticket
    // 1. No matter what day of the week its placed
    // 2. It should increase the price by 2 euros instead of 3 if its a ticket purchased by a student.
    [Test]
    public void StudentPricingStrategy_PremiumTicketShouldAdd3EuroToRegularOrderDuringTheWeekend()
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
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(true));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 3));
        });
    }


    // Premium tickets should increase the price of a ticket
    // 1. No matter what day of the week its placed
    // 2. It should increase the price by 2 euros instead of 3 if its a ticket purchased by a student.
    [Test]
    public void StudentPricingStrategy_PremiumTicketShouldAdd3EuroToRegularOrderDuringTheRegularWeekdays()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 01); // Thursday February 1st.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);
        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 3

        Order order = new(1, studentPricing);
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

        // act
        order.AddSeatReservation(movieTicket1);

        // assert 
        Assert.Multiple(() =>
        {
            Assert.That(movieScreening.IsWeekend(), Is.EqualTo(false));
            Assert.That(order.CalculatePrice(), Is.EqualTo(pricePerSeat + 3));
        });
    }


    // The fees should not be placed on tickets that should be free.
    // 1. Second tickets should not get a fee
    // 2. No matter what type of role they have.
    [Test]
    public void StudentPricingStrategy_PremiumTicketNoIncreasedFeesForFreeSecondTicketForStudents()
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
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

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

    // The fees should not be placed on tickets that should be free.
    // 1. Second tickets should not get a fee
    // 2. No matter what type of role they have.
    [Test]
    public void StudentPricingStrategy_PremiumTicketNoIncreasedFeesForFreeSecondTicketForRegular()
    {
        // arrange
        const bool studentPricing = false;
        const bool premiumTickets = true;
        const int pricePerSeat = 10;
        var date = new DateTime(2024, 02, 01); // Thursday February 1st.

        Movie movie = new("Terminator 2");
        MovieScreening movieScreening = new(date, pricePerSeat, movie);

        MovieTicket movieTicket1 = new(movieScreening, premiumTickets, 1, 1); // 10 + 3
        MovieTicket movieTicket2 = new(movieScreening, premiumTickets, 1, 2); // free
        MovieTicket movieTicket3 = new(movieScreening, premiumTickets, 1, 3); // 10 + 3
        MovieTicket movieTicket4 = new(movieScreening, premiumTickets, 1, 4); // free 
        MovieTicket movieTicket5 = new(movieScreening, premiumTickets, 1, 5); // 10 +3 
        Order order = new(1, studentPricing);
        var strategy = new StudentPricingPriceStrategy();
        order.SetCalculatePriceStrategy(strategy);

        
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
            Assert.That(order.CalculatePrice(), Is.EqualTo((pricePerSeat + 3) * 3));
        });
    }
}