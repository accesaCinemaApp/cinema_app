using System;

namespace CinemaApp.Models
{
    public class Movie
    {
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
            Title = T;
            Description = D;
            ReleasedDate = RD;
            Rating = R;
            Duration = Dur;
        }
    }
}
