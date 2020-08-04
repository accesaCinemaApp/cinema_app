using System;

namespace CinemaApp.Models
{
    public struct Seat : IEquatable<Seat>
    {
        // data fields
        public char Row { get; set; }
        public int Nr { get; set; }

        // custom equality checking method
        public bool Equals(Seat other)
        {
            return Row == other.Row && Nr == other.Nr;
        }
    };
}