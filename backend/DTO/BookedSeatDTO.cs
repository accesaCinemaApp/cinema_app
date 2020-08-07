using CinemaApp.Models;

namespace CinemaApp.DTO
{
    public class BookedSeatDTO
    {
        public int ID { get; set; }
        public Seat Seat { get; set; }
        public Booking Booking { get; set; }

        public BookedSeatDTO() { }

        public BookedSeatDTO(BookedSeat bookedSeat)
        {
            ID = bookedSeat.ID;
            Seat = bookedSeat.Seat;
            Booking = bookedSeat.Booking;
        }

        public BookedSeat DTOToModel()
        {
            return new BookedSeat
            {
                ID = ID,
                Seat = Seat,
                Booking = Booking
            };
        }
    }
}
