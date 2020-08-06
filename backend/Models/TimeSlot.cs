using System;

namespace CinemaApp.Models
{
    public class TimeSlot 
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Movie Movie { get; set; }
    }
}
