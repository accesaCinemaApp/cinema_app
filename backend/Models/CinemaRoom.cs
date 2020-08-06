using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class CinemaRoom
    {
        // data fields
        public int ID { get; set; }
        public int RoomNr { get; set; }
        public List<Seat> Seats { get; set; }
    }
}