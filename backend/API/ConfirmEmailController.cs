using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmEmailController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public ConfirmEmailController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/ConfirmEmail/<tokenValue>
        [HttpGet("{token}")]
        public async Task<ActionResult> Confirm(string token)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(ub => ub.Token == token);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Token = null;
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return Accepted();
        }
    }
}
