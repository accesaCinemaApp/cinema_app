namespace CinemaApp.Models
{
    public class BookedSeat
    {
        public int ID { get; set; }
        public Seat Seat { get; set; }
        public Booking Booking { get; set; }
    }
}
