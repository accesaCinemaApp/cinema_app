using CinemaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public TimeSlotDTO TimeSlot { get; set; }
        public List<BookedSeatDTO> BookedSeats { get; set; }

        public string Token { get; set; }

        public BookingDTO() { }

        public BookingDTO(Booking booking)
        {
            ID = booking.ID;
            Email = booking.Email;
            TimeSlot = new TimeSlotDTO(booking.TimeSlot);
            BookedSeats = booking.BookedSeats.Select(bookedSeat => new BookedSeatDTO(bookedSeat)).ToList();
        }

        public Booking DTOToModel()
        {
            return new Booking
            {
                ID = ID,
                Email = Email,
                TimeSlot = TimeSlot.DTOToModel(),
                BookedSeats = BookedSeats.Select(bookedSeat => bookedSeat.DTOToModel()).ToList(),
                Token = Token
            };
        }
    }
}
