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
        public async Task<ActionResult<IEnumerable<CinemaRoomDTO>>> GetCinemaRoom()
        {
            return await _context.CinemaRooms.Select(cinemaRoom => ItemToDTO(cinemaRoom)).ToListAsync();
        }

        // GET api/<CinemaRoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaRoomDTO>> GetCinemaRoom(int id)
        {
            var cinemaRoom = await _context.CinemaRooms.FindAsync(id);

            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return ItemToDTO(cinemaRoom);
        }

        // POST api/<CinemaRoomsController>
        [HttpPost]
        public async Task<ActionResult<CinemaRoomDTO>> PostCinemaRoom(CinemaRoom cinemaRoom)
        {
            _context.CinemaRooms.Add(new CinemaRoom
            {
                RoomNr = cinemaRoom.RoomNr,
                Seats = cinemaRoom.Seats
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCinemaRoom), new { id = cinemaRoom.RoomNr }, cinemaRoom);
        }

        // PUT api/<CinemaRoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinemaRoom(int id, CinemaRoom cinemaRoom)
        {
            if (id != cinemaRoom.RoomNr)
            {
                return BadRequest();
            }

            _context.Entry(cinemaRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<CinemaRoomsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CinemaRoomDTO>> Delete(int id)
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
            return _context.CinemaRooms.Any(e => e.RoomNr == id);
        }

        private static CinemaRoomDTO ItemToDTO(CinemaRoom cinemaRoom) =>
            new CinemaRoomDTO
            {
                Id = cinemaRoom.Id,
                RoomNr = cinemaRoom.RoomNr,
                Seats = cinemaRoom.Seats
            };
    }
}
