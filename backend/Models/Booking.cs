using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class Booking
    {
        public int ID { get; set; }

        public string Email { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
