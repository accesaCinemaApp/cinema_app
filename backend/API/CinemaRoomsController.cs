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
            var cinemaRoom = await _context.CinemaRooms.Include(cinemaRoom => cinemaRoom.Seats)
                .FirstOrDefaultAsync(cinemaRoom => cinemaRoom.ID == id);

            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return ItemToDTO(cinemaRoom);
        }

        private static CinemaRoomDTO ItemToDTO(CinemaRoom cinemaRoom) => new CinemaRoomDTO(cinemaRoom);
    }
}
