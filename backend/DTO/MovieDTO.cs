using CinemaApp.Models;
using System;
using System.Reflection;

namespace CinemaApp.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public float Rating { get; set; }
        public string Duration { get; set; }
        public string CoverPhoto { get; set; }


        public MovieDTO(Movie movie)
        {
            ID = movie.ID;
            Title = movie.Title;
            Description = movie.Description;
            ReleasedDate = movie.ReleasedDate;
            Rating = movie.Rating;
            Duration = movie.Duration;
            CoverPhoto = movie.CoverPhoto;
        }

        public Movie DTOToModel()
        {
            return new Movie
            {
                ID = ID,
                Title = Title,
                Description = Description,
                ReleasedDate = ReleasedDate,
                Rating = Rating,
                Duration = Duration
            };
        }
    }

}
