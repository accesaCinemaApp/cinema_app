﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.DTO;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public BookingsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookings()
        {
            return await _context.Bookings.Include(booking => booking.BookedSeats).Select(booking => ItemToDTO(booking)).ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking(int id)
        {
            var booking = await _context.Bookings.Include(booking => booking.BookedSeats).SingleOrDefaultAsync(booking => booking.ID == id);

            if (booking == null)
            {
                return NotFound();
            }

            return ItemToDTO(booking);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingDTO booking)
        {
            if (id != booking.ID)
            {
                return BadRequest();
            }

            if (!BookingExists(id))
            {
                return NotFound();
            }
            _context.Entry(booking).State = EntityState.Modified;
            if ((booking.BookedSeats.Equals(null)))
            {
                _context.Entry(booking).Property("Seats").IsModified = false;
            }
            if (booking.TimeSlot.Equals(null))
            {
                _context.Entry(booking).Property("TimeSlot").IsModified = false;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(BookingDTO booking)
        {
            await _context.Bookings.AddAsync(booking.DTOToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.ID }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDTO>> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.ID == id);
        }

        private static BookingDTO ItemToDTO(Booking booking) => new BookingDTO(booking);
    }
}
