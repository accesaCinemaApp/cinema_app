using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class BookedSeat
    {
        public int ID { get; set; }
        public Seat Seat { get; set; }
        public Booking Booking { get; set; }
    }
}
