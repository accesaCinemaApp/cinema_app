using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.DTO;

namespace CinemaApp.Models
{
    public class TimeSlot 
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Movie Movie { get; set; }

        
    }
}
