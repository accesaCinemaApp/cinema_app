using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Column("varchar(250)")]
        public string Title { get; set; }
        [Column("varchar(250)")]
        public string Description { get; set; }
        [Column("date")]
        public DateTime ReleasedDate { get; set; }
        [Column("float")]
        public float Rating { get; set; }
        [Column("time")]
        public TimeSpan Duration { get; set; }
        [Column("image")]
        public byte[] CoverPhoto { get; set; }
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
