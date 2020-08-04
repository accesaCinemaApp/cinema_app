using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class TimeSlot
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Movie Movie { get; set; }

    }
}
