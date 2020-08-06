using CinemaApp.Models;
using CinemaApp.Utilities;
using System;
using System.Text.Json.Serialization;

namespace CinemaApp.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public float Rating { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Duration { get; set; }

        public MovieDTO() { }

        public MovieDTO(Movie movie)
        {
            ID = movie.ID;
            Title = movie.Title;
            Description = movie.Description;
            ReleasedDate = movie.ReleasedDate;
            Rating = movie.Rating;
            Duration = movie.Duration;
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
