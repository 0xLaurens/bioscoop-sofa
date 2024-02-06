using System.Text.Json.Serialization;

namespace Data;

public class MovieTicket(MovieScreening movieScreening, bool isPremium, int rowNr, int seatNr)
{
   // In order to serialize the object the fields have to be public
   // The fields are encapsulated to prevent them being changed.
   
   public MovieScreening _movieScreening = movieScreening;
   [JsonPropertyName("isPremium")]
   public bool IsPremium { get; } = isPremium;
   [JsonPropertyName("rowNr")]
   public int RowNr { get; } = rowNr;
   [JsonPropertyName("seatNr")]
   public int SeatNr { get; } = seatNr;
   public bool IsPremiumTicket()
   {
      return IsPremium;
   }

   public double GetPrice()
   {
      return _movieScreening.GetPricePerSeat();
   }

   public MovieScreening GetScreening()
   {
      return _movieScreening;
   }

   public override string ToString()
   {
      return GetScreening() + ", Row: " + rowNr + ", Seat: " + seatNr + ", Premium: " + isPremium; 
   }
}