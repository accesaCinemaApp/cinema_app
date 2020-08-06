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
        [Column("ID", TypeName = "varchar(250)")]
        public int ID { get; set; }
        [Column("Title", TypeName = "varchar(250)")]
        public string Title { get; set; }
        [Column("Description", TypeName = "varchar(250)")]
        public string Description { get; set; }
        [Column("Release Data", TypeName = "date")]
        public DateTime ReleasedDate { get; set; }
        [Column("Rating", TypeName = "float")]
        public float Rating { get; set; }
        [Column("Duration", TypeName = "varchar(250)")]
        public string Duration { get; set; }
        [Column("CoverPhoto", TypeName = "varchar(250)")]
        public string CoverPhoto { get; set; }



        public Movie()
        { }
        public Movie(string T, string D, DateTime RD, float R, string Dur)
        {
            Title = T;
            Description = D;
            ReleasedDate = RD;
            Rating = R;
            Duration = Dur;
        }
    }
}
