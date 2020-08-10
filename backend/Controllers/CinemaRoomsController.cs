using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class CinemaRoomsController : Controller
    {
        private readonly CinemaDbContext _context;

        public CinemaRoomsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: CinemaRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.CinemaRooms.ToListAsync());
        }

        // GET: CinemaRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRooms.Include(cinemaRoom => cinemaRoom.Seats)
                .FirstOrDefaultAsync(cinemaRoom => cinemaRoom.ID == id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return View(cinemaRoom);
        }

        // GET: CinemaRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: CinemaRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRooms.Include(cinemaRoom => cinemaRoom.Seats).FirstOrDefaultAsync(cinemaRoom => cinemaRoom.ID == id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            ViewData["roomID"] = id;
            return View(cinemaRoom);
        }


        // GET: CinemaRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaRoom = await _context.CinemaRooms.Include(cinemaRoom => cinemaRoom.Seats)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cinemaRoom == null)
            {
                return NotFound();
            }

            return View(cinemaRoom);
        }

        // POST: CinemaRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaRoom = await _context.CinemaRooms.FindAsync(id);
            _context.CinemaRooms.Remove(cinemaRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaRoomExists(int id)
        {
            return _context.CinemaRooms.Any(e => e.ID == id);
        }
    }
}
