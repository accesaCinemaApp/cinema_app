using System;

namespace CinemaApp.Models
{
    public class Seat : IEquatable<Seat>
    {
        // data fields

        public int Id { get; set; }
        public char Row { get; set; }
        public int Nr { get; set; }
        public Booking Booking { get; set; }

        // custom equality checking method
        public bool Equals(Seat other)
        {
            return Row == other.Row && Nr == other.Nr;
        }
    };
}