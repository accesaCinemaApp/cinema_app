using CinemaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.DTO
{
    public class CinemaRoomDTO
    {
        public int ID { get; set; }
        public int RoomNr { get; set; }
        public List<SeatDTO> Seats { get; set; }

        public CinemaRoomDTO(CinemaRoom cinemaRoom)
        {
            ID = cinemaRoom.ID;
            RoomNr = cinemaRoom.RoomNr;
            Seats = cinemaRoom.Seats.Select(seat => new SeatDTO(seat)).ToList();
        }

        public CinemaRoom DTOToModel()
        {
            return new CinemaRoom
            {
                ID = ID,
                RoomNr = RoomNr,
                Seats = Seats.Select(seat => seat.DTOToModel()).ToList()
            };
        }
    }
}
