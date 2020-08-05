using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
