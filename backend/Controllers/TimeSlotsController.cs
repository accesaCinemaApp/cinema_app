using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class TimeSlotsController : Controller
    {
        private readonly CinemaDbContext _context;

        public TimeSlotsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: TimeSlots
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeSlots.Include(t => t.CinemaRoom).Include(t => t.Movie).ToListAsync());
        }

        // GET: TimeSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlots.Include(t => t.CinemaRoom).Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        // GET: TimeSlots/Create
        public IActionResult Create()
        {
            var cinemaRooms = _context.CinemaRooms.Select(item => new SelectListItem
            {
                Value = item.ID.ToString(),
                Text = item.RoomNr.ToString()
            });
            var movies = _context.Movies.Select(item => new SelectListItem
            {
                Value = item.ID.ToString(),
                Text = item.Title
            });
            ViewData["cinemaRooms"] = cinemaRooms;
            ViewData["movies"] = movies;

            return View();
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MovieID,Time,CinemaRoomID")] TimeSlotViewModel timeSlotVM)
        {
            TimeSlot timeSlot = null;
            if (ModelState.IsValid)
            {
                timeSlot = ModelFromVM(timeSlotVM);
                _context.Add(timeSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSlot);
        }

        // GET: TimeSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlots.Include(t => t.CinemaRoom).Include(t => t.Movie)
                .FirstOrDefaultAsync(t => t.ID == id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            var cinemaRooms = _context.CinemaRooms.Select(item => new SelectListItem
            {
                Value = item.ID.ToString(),
                Text = item.RoomNr.ToString()
            });
            var movies = _context.Movies.Select(item => new SelectListItem
            {
                Value = item.ID.ToString(),
                Text = item.Title
            });
            ViewData["cinemaRooms"] = cinemaRooms;
            ViewData["movies"] = movies;
            return View(ModelToVM(timeSlot));
        }

        // POST: TimeSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MovieID,Time,CinemaRoomID")] TimeSlotViewModel timeSlotVM)
        {
            if (id != timeSlotVM.ID)
            {
                return NotFound();
            }

            TimeSlot timeSlot = null;
            if (ModelState.IsValid)
            {

                timeSlot = ModelFromVM(timeSlotVM);
                try
                {
                    _context.Update(timeSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSlotExists(timeSlot.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeSlotVM);
        }

        // GET: TimeSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlots.Include(t => t.CinemaRoom).Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSlotExists(int id)
        {
            return _context.TimeSlots.Any(e => e.ID == id);
        }

        private TimeSlot ModelFromVM(TimeSlotViewModel VM) => new TimeSlot
            {
                ID = VM.ID,
                Movie = _context.Movies.Find(VM.MovieID),
                Time = VM.Time,
                CinemaRoom = _context.CinemaRooms.Find(VM.CinemaRoomID)
            };

        private TimeSlotViewModel ModelToVM(TimeSlot timeSlot) => new TimeSlotViewModel
        {
            ID = timeSlot.ID,
            MovieID = timeSlot.Movie.ID,
            Time = timeSlot.Time,
            CinemaRoomID = timeSlot.CinemaRoom.ID
        };
    }
}
