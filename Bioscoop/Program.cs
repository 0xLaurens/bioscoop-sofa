// See https://aka.ms/new-console-template for more information

using Data;

Movie movie = new("Terminator 2");
MovieScreening movieScreening = new(new DateTime(2024, 01, 01), 10, movie);
MovieTicket movieTicket1 = new(movieScreening, false, 1, 1);
MovieTicket movieTicket2 = new(movieScreening, false, 1, 2);
MovieTicket movieTicket3 = new(movieScreening, true, 1, 3);
MovieTicket movieTicket4 = new(movieScreening, true, 1, 4);
MovieTicket movieTicket5 = new(movieScreening, true, 1, 5);
MovieTicket movieTicket6 = new(movieScreening, true, 1, 6);
Order order = new(1, true);

order.AddSeatReservation(movieTicket1);
order.AddSeatReservation(movieTicket2);
order.AddSeatReservation(movieTicket3);
order.AddSeatReservation(movieTicket4);
order.AddSeatReservation(movieTicket5);
order.AddSeatReservation(movieTicket6);

Console.WriteLine(order.CalculatePrice());
order.Export(TicketExportFormat.Json);