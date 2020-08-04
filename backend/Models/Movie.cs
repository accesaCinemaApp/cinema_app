using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CinemaApp.Models
{
    public class Movie
    {
        private static int counter = 0; //for auto ID
        private int _ID;
        private string _Title, _Description;
        private DateTime _ReleasedDate;
        private float _Rating;
        private TimeSpan _Duration;
        public int ID { get => _ID; set => _ID = value; }
        public string Title { get => _Title; set => _Title = value; }
        public string Description { get => _Description; set => _Description = value; }
        public DateTime ReleasedDate { get => _ReleasedDate; set => _ReleasedDate = value; }
        public float Rating { get => _Rating; set => _Rating = value; }
        public TimeSpan Duration { get => _Duration; set => _Duration = value; }
        public Movie()
        {

        }
        public Movie(string T,string D,DateTime RD,float R,TimeSpan Dur)
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
