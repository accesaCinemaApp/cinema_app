using CinemaApp.Models;

namespace CinemaApp.DTO
{
    public class SeatDTO
    {
        // data fields
        public int ID { get; set; }
        public char Row { get; set; }
        public int Nr { get; set; }

        public bool? Available { get; set; }

        public SeatDTO() { }

        public SeatDTO(Seat seat)
        {
            ID = seat.ID;
            Row = seat.Row;
            Nr = seat.Nr;
            Available = seat.Available;
        }

        public Seat DTOToModel()
        {
            return new Seat
            {
                ID = ID,
                Row = Row,
                Nr = Nr,
                Available = Available
            };
        }
    }
}