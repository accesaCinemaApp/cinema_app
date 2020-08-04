using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class CinemaRoomDTO
    {
        public int RoomNr { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
