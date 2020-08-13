using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Models
{
    public class Seat
    {
        // data fields
        public int ID { get; set; }
        public char Row { get; set; }
        public int Nr { get; set; }

        [NotMapped]
        public bool? Available { get; set; }
    };
}