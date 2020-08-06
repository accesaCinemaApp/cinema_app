using CinemaApp.Models;

namespace CinemaApp.DTO
{
    public class SeatDTO
    {
        // data fields
        public int ID { get; set; }
        public char Row { get; set; }
        public int Nr { get; set; }

        // custom equality checking method
        public bool Equals(Seat other)
        {
            return other != null && Row == other.Row && Nr == other.Nr;
        }

        public SeatDTO(Seat seat)
        {
            ID = seat.ID;
            Row = seat.Row;
            Nr = seat.Nr;
        }

        public Seat DTOToModel()
        {
            return new Seat
            {
                ID = ID,
                Row = Row,
                Nr = Nr
            };
        }
    }
}