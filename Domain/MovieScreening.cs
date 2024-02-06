using System.Collections;

namespace Data;

public class MovieScreening(DateTime dateAndTime, decimal pricePerSeat, Movie movie)
{
   public decimal GetPricePerSeat()
   {
      return pricePerSeat;
   }

   public DateTime GetDateAndTime()
   {
      return dateAndTime;
   }
   
   public bool IsWeekend()
   {
      return GetDateAndTime().DayOfWeek == DayOfWeek.Sunday
             || GetDateAndTime().DayOfWeek == DayOfWeek.Saturday;
   }

   public override string ToString()
   {
      return "Movie: " + movie + ", Date: " + dateAndTime + ", Price: " + pricePerSeat;
   }
}