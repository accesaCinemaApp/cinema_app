using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Models;

namespace CinemaApp.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }

        public TimeSlot TimeSlot { get; set; }

        public List<Seat> Seats { get; set; }

    }
}
