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
        public List<SeatDTO> Seats { get; set; }

        public BookingDTO(Booking booking)
        {
            ID = booking.ID;
            Email = booking.Email;
            TimeSlot = new TimeSlotDTO(booking.TimeSlot);
            Seats = booking.Seats.Select(seat => new SeatDTO(seat)).ToList();
        }

        public Booking DTOToModel()
        {
            return new Booking
            {
                ID = ID,
                Email = Email,
                TimeSlot = TimeSlot.DTOToModel(),
                Seats = Seats.Select(seat => seat.DTOToModel()).ToList()
            };
        }
    }
}
