using System.Collections;

namespace Data;

public class Movie(string title)
{
   private string _title = title;
   private List<MovieScreening> _screenings = new();

   public void AddScreening(MovieScreening screening)
   {
      _screenings.Add(screening);
   }
}