using Microsoft.EntityFrameworkCore;
using CinemaApp.DTO;

namespace CinemaApp.Models
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
            : base() 
        {
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
