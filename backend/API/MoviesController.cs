using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;
using CinemaApp.DTO;
using System.Text.Json;

namespace CinemaApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public MoviesController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            return await _context.Movies.Select(movie => ItemToDTO(movie)).ToListAsync();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return ItemToDTO(movie);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDTO movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            if (!MovieExists(id))
            {
                return NotFound();
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Movie
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieDTO movie)
        {
            _context.Movies.Add(movie.DTOToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.ID }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDTO>> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }

        private static MovieDTO ItemToDTO(Movie movie) => new MovieDTO(movie);
    }
}
