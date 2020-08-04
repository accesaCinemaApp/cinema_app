using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options)
            : base(options)
        {}
        public CalendarContext() { }

        public DbSet<Calendar> Calendars { get; set; }

    }
}
