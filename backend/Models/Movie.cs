using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class Movie
    {
        private static int counter = 0;

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public float Rating { get; set; }
        public TimeSpan Duration { get; set; }
        public Movie()
        { }
        public Movie(string T, string D, DateTime RD, float R, TimeSpan Dur)
        {
            ID = counter++;
            Title = T;
            Description = D;
            ReleasedDate = RD;
            Rating = R;
            Duration = Dur;
        }
    }
}
