﻿using CinemaApp.Models;
using System;

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

        
    }
}