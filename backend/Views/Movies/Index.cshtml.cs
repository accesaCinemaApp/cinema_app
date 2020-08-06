using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;

namespace CinemaApp.Views.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CinemaApp.Models.CinemaDbContext _context;

        public IndexModel(CinemaApp.Models.CinemaDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
