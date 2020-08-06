using System;
using CinemaApp.Models;

namespace CinemaApp.DTO
{
    public class TimeSlotDTO
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Movie Movie { get; set; }

    }
}