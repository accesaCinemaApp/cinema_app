using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Models
{
    // empty declaration of the class Movie until it gets committed
    public class Movie { }

    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }


        public DbSet<Seat> Seats { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
