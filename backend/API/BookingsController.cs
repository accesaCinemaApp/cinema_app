using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CinemaApp.DTO;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Http.Extensions;
using System.Data;

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

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<BookingDTO>> PostBooking(BookingViewModel bookingVM)
        {
            if(ModelState.IsValid)
            {
                Booking booking;
                try
                {
                    booking = ModelFromVM(bookingVM);
                }
                catch(ArgumentException)
                {
                    return BadRequest();
                }
                catch(InvalidOperationException)
                {
                    return BadRequest();
                }
                catch (DBConcurrencyException)
                {
                    return Conflict();
                }

                byte[] token = new byte[16];
                new RNGCryptoServiceProvider().GetBytes(token);
                booking.Token = BitConverter.ToString(token).Replace("-", "");

                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();

                var body = "<p>You booked {0} seats for the movie {1} at {2}. </p><p>Click the link bellow to confirm:</p> " +
                    "<a href='{3}'>Confirm Booking</a>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(booking.Email));
                message.From = new MailAddress(booking.Email);
                message.Subject = "Confirm movie booking";
                string url = new UriBuilder()
                {
                    Scheme = HttpContext.Request.Scheme,
                    Host = HttpContext.Request.Host.ToString().Trim(new char[] { '[', ']' }),
                    Path = $"api/ConfirmEmail/{booking.Token}"
                }.ToString();
                message.Body = string.Format(body, booking.BookedSeats.Count, booking.TimeSlot.Movie.Title, booking.TimeSlot.Time, url);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "cinemaappburneremail@gmail.com",  // to be replaced
                        Password = "oParola42"  // to be replaced
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    return Created(HttpContext.Request.GetDisplayUrl(), null);
                }
            }

            return BadRequest();
        }

        private static BookingDTO ItemToDTO(Booking booking) => new BookingDTO(booking);
        private Booking ModelFromVM(BookingViewModel VM)
        {
            var result = new Booking
            {
                ID = VM.ID,
                Email = VM.Email,
                TimeSlot = _context.TimeSlots.Include(ts => ts.Movie).FirstOrDefault(ts => ts.ID == VM.TimeSlotID)
            };

            if (result.TimeSlot == null) throw new ArgumentException();

            var seatList = _context.TimeSlots.Include(ts => ts.CinemaRoom).ThenInclude(cr => cr.Seats)
                .Where(t => t.ID == VM.TimeSlotID).SelectMany(t => t.CinemaRoom.Seats).ToList();
            var bookedSeats = (_context.Bookings.Include(b => b.TimeSlot)
                .Include(b => b.BookedSeats).ThenInclude(bs => bs.Seat).ToList())
                .Where(b => b.TimeSlot.ID == VM.TimeSlotID)
                .SelectMany(b => b.BookedSeats)
                .ToList();
            var list = new List<BookedSeat>();
            VM.BookedSeatIDs.ForEach(elem =>
            {
                var seen = false;
                bookedSeats.ForEach(bs =>
                {
                    if (bs.Seat.ID == elem)
                        seen = true;
                });
                if (seen) throw new DBConcurrencyException();

                var item = seatList.First(s => s.ID == elem);
                list.Add(new BookedSeat { Seat = item, Booking = result });
            });
            result.BookedSeats = list;
            return result;
        }
    }
}
