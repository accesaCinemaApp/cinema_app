using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;
using CinemaApp.DTO;

namespace CinemaApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public TimeSlotsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeSlots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetTimeSlots()
        {
            return await _context.TimeSlots.Select(timeSlot => ItemToDTO(timeSlot)).ToListAsync();
        }

        // GET: api/TimeSlots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlotDTO>> GetTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return ItemToDTO(timeSlot);
        }

        // PUT: api/TimeSlots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSlot(int id, TimeSlotDTO timeSlot)
        {
            if (id != timeSlot.ID)
            {
                return BadRequest();
            }

            if (!TimeSlotExists(id))
            {
                return NotFound();
            }

            _context.Entry(timeSlot).State = EntityState.Modified;
            if ((timeSlot.CinemaRoom.Equals(null)))
            {
                _context.Entry(timeSlot).Property("CinemaRoom").IsModified = false;
            }
            if (timeSlot.Movie.Equals(null))
            {
                _context.Entry(timeSlot).Property("Movie").IsModified = false;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TimeSlots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TimeSlot>> PostTimeSlot(TimeSlotDTO timeSlot)
        {
            await _context.TimeSlots.AddAsync(timeSlot.DTOToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTimeSlot), new { id = timeSlot.ID }, timeSlot);
        }

        // DELETE: api/TimeSlots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSlotDTO>> DeleteTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeSlotExists(int id)
        {
            return _context.TimeSlots.Any(e => e.ID == id);
        }

        private static TimeSlotDTO ItemToDTO(TimeSlot timeSlot) => new TimeSlotDTO(timeSlot);
    }
}
