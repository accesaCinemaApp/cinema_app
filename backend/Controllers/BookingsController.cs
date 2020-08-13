using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CinemaDbContext _context;

        public BookingsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.Include(b => b.TimeSlot).Include(b => b.TimeSlot.Movie).Include(b => b.TimeSlot.CinemaRoom).ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.Include(b => b.TimeSlot)
                .Include(b => b.TimeSlot.Movie).Include(b => b.TimeSlot.CinemaRoom)
                .Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            var timeSlotList = (await _context.TimeSlots.Include(t => t.Movie).ToListAsync())
                .Where(timeSlot => DateTime.Now <= timeSlot.Time).Select(timeSlot => new SelectListItem
                    {
                        Value = timeSlot.ID.ToString(),
                        Text = timeSlot.Movie.Title + " - " + timeSlot.Time.ToString()
                    })
                .ToList();

            ViewData["timeSlotList"] = timeSlotList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectSeats([Bind("ID,Email,TimeSlotID")] BookingViewModel bookingVM)
        {
            var seatList = (await _context.TimeSlots
                .Include(t => t.CinemaRoom).Include(t => t.CinemaRoom.Seats)
                .ToListAsync())
                .Where(timeSlot => DateTime.Now <= timeSlot.Time)
                .Where(t => t.ID == bookingVM.TimeSlotID)
                .SelectMany(t => t.CinemaRoom.Seats)
                .ToList();
            var bookedSeatList = (await _context.Bookings.Include(b => b.TimeSlot).Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).ToListAsync())
                .Where(b => DateTime.Now <= b.TimeSlot.Time)
                .Where(b => b.TimeSlot.ID == bookingVM.TimeSlotID)
                .SelectMany(b => b.BookedSeats)
                .ToList();
            var availableSeatList = FilterSeats(seatList, bookedSeatList).Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Row + ", " + s.Nr
            });

            ViewData["availableSeatList"] = availableSeatList;
            return View(bookingVM);
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,TimeSlotID,BookedSeatIDs")] BookingViewModel bookingVM)
        {
            Booking booking = null;
            if (ModelState.IsValid)
            {
                booking = ModelFromVM(bookingVM);
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingVM);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.Include(b => b.TimeSlot).FirstOrDefaultAsync(b => b.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            var seatList = (await _context.TimeSlots
                .Include(t => t.CinemaRoom).Include(t => t.CinemaRoom.Seats)
                .ToListAsync())
                .Where(t => DateTime.Now <= t.Time)
                .Where(t => t.ID == booking.TimeSlot.ID)
                .SelectMany(t => t.CinemaRoom.Seats)
                .ToList();
            var bookedSeatList = (await _context.Bookings.Include(b => b.TimeSlot).Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).ToListAsync())
                .Where(b => DateTime.Now <= b.TimeSlot.Time)
                .Where(b => b.TimeSlot.ID == booking.TimeSlot.ID)
                .Where(b => b.ID != id)
                .SelectMany(b => b.BookedSeats)
                .ToList();

            var availableSeatList = FilterSeats(seatList, bookedSeatList)
                .Select(s => new SelectListItem
                    {
                        Value = s.ID.ToString(),
                        Text = s.Row + ", " + s.Nr
                    });
            
            ViewData["availableSeatList"] = availableSeatList;
            return View(ModelToVM(booking));
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,BookedSeatIDs")] BookingViewModel bookingVM)
        {
            Booking booking = null;
            if (id != bookingVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    booking = ModelFromVM(bookingVM);
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(bookingVM.ID))
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
            return View(bookingVM);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.Include(b => b.TimeSlot)
                .Include(b => b.TimeSlot.Movie).Include(b => b.TimeSlot.CinemaRoom)
                .Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.ID == id);
        }

        private List<Seat> FilterSeats(List<Seat> seats, List<BookedSeat> bookedSeats)
        {
            List<Seat> result = new List<Seat>();
            seats.ForEach(seat =>
            {
                var hasBookings = false;
                bookedSeats.ForEach(bookedSeat =>
                {
                    if (!hasBookings && seat.ID == bookedSeat.Seat.ID)
                    {
                        hasBookings = true;
                    }
                });

                if (!hasBookings)
                {
                    result.Add(seat);
                }
            });

            return result;
        }

        private Booking ModelFromVM(BookingViewModel VM)
        {
            var result = new Booking
            {
                ID = VM.ID,
                Email = VM.Email,
                TimeSlot = _context.TimeSlots.Find(VM.TimeSlotID)
            };

            var seatList = _context.CinemaRooms.Include(cr => cr.Seats).SelectMany(cr => cr.Seats).ToList();
            var list = new List<BookedSeat>();
            VM.BookedSeatIDs.ForEach(elem =>
            {
                var item = seatList.FirstOrDefault(s => s.ID == elem);
                list.Add(new BookedSeat { Seat = item, Booking = result });
            });
            result.BookedSeats = list;
            return result;
        }

        private static BookingViewModel ModelToVM(Booking booking) => new BookingViewModel
        {
            ID = booking.ID,
            Email = booking.Email,
            TimeSlotID = booking.TimeSlot.ID,
            BookedSeatIDs = booking.BookedSeats.Select(bs => bs.ID).ToList()
        };
    }
}
