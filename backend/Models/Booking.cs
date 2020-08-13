using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public List<BookedSeat> BookedSeats { get; set; }
        public string Token { get; set; }
    }
}
