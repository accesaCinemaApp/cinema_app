using System;
using System.Collections.Generic;
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
    public class CinemaRoomsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public CinemaRoomsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/<CinemaRoomsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaRoomDTO>>> GetCinemaRooms()
        {
            return await _context.CinemaRooms.Select(cinemaRoom => ItemToDTO(cinemaRoom)).ToListAsync();
        }

        // GET api/<CinemaRoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaRoomDTO>> GetCinemaRoom(int id)
        {
            var cinemaRoom = await _context.CinemaRooms.Include(cinemaRoom => cinemaRoom.Seats).SingleOrDefaultAsync(cinemaRoom => cinemaRoom.ID == id);

            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return ItemToDTO(cinemaRoom);
        }

        // POST api/<CinemaRoomsController>
        [HttpPost]
        public async Task<ActionResult<CinemaRoomDTO>> PostCinemaRoom(CinemaRoomDTO cinemaRoom)
        {
            _context.CinemaRooms.Add(cinemaRoom.DTOToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCinemaRoom), new { id = cinemaRoom.ID }, cinemaRoom);
        }

        // PUT api/<CinemaRoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinemaRoom(int id, CinemaRoomDTO cinemaRoom)
        {
            if (id != cinemaRoom.ID)
            {
                return BadRequest();
            }

            if (!CinemaRoomExists(id))
            {
                return NotFound();
            }

            _context.Entry(cinemaRoom).State = EntityState.Modified;
            if ((cinemaRoom.Seats.Equals(null)))
            {
                _context.Entry(cinemaRoom).Property("Seats").IsModified = false;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<CinemaRoomsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CinemaRoomDTO>> DeleteCinemaRoom(int id)
        {
            var cinemaRoom = await _context.CinemaRooms.FindAsync(id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            _context.CinemaRooms.Remove(cinemaRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CinemaRoomExists(int id)
        {
            return _context.CinemaRooms.Any(e => e.ID == id);
        }

        private static CinemaRoomDTO ItemToDTO(CinemaRoom cinemaRoom) => new CinemaRoomDTO(cinemaRoom);
    }
}
