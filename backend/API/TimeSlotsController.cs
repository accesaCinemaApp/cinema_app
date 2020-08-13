using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;
using CinemaApp.DTO;
using System;

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
            return await _context.TimeSlots.Include(ts => ts.Movie).Include(ts => ts.CinemaRoom).Select(timeSlot => ItemToDTO(timeSlot)).ToListAsync();
        }

        // GET: api/TimeSlots/2020-08-13
        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetTimeSlots(string date)
        {
            var dateComponents = date.Split('-');
            if(dateComponents.Length != 3 || !dateComponents.All(dtc => int.TryParse(dtc, out var _i)))
            {
                return BadRequest();
            }
            var dateTime = new DateTime(int.Parse(dateComponents[0]),
                                            int.Parse(dateComponents[1]),
                                            int.Parse(dateComponents[2]));

            var timeSlots = await _context.TimeSlots
                .Where(ts => ts.Time.Date == dateTime.Date)
                .Include(ts => ts.Movie).Include(ts => ts.CinemaRoom)
                .Select(ts => ItemToDTO(ts)).ToListAsync();

            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound();
            }
            return timeSlots;
        }

        // GET: api/TimeSlots/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeSlotDTO>> GetTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots
                .Include(ts => ts.CinemaRoom).ThenInclude(cr => cr.Seats)
                .Include(ts => ts.Movie)
                .FirstOrDefaultAsync(ts => ts.ID == id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            var bookedSeatList = (await _context.Bookings.Include(b => b.TimeSlot)
                .Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).ToListAsync())
                .Where(b => b.TimeSlot.ID == id)
                .SelectMany(b => b.BookedSeats)
                .ToList();

            timeSlot.CinemaRoom.Seats.ForEach(seat =>
            {
                var seen = false;
                bookedSeatList.ForEach(bookedSeat =>
                {
                    if (!seen && seat.ID == bookedSeat.Seat.ID)
                    {
                        seat.Available = false;
                        seen = true;
                    }
                });

                if (!seen)
                {
                    seat.Available = true;
                }
            });

            return ItemToDTO(timeSlot);
        }

        private static TimeSlotDTO ItemToDTO(TimeSlot timeSlot) => new TimeSlotDTO(timeSlot);
    }
}
