using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class BookingMovieModel
    {
        public int Id { get; set; }

    }
    public class CreateBookingViewModel
    {
        public string Email { get; set; }
        public int MovieId { get; set; }
        public List<SelectListItem> MovieList { get; set; }
    }
}
