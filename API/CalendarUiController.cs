using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.API
{
    [Route("calendar")]
    [ApiController]
    public class CalendarUiController : Controller
    {
       [HttpGet]
        public IActionResult Index()
        {

            var date = new DatesModel()
            {
                Date = DateTime.Now
            };


            return View(date);
        }
       [HttpPost]
        public IActionResult SeeMovies()
        {
            var d = DateTime.Now;
            var duration = TimeSpan.MaxValue;
            var movie=new Movie("Dracula","It's a small description", d, 4.5f, duration);


            return View(movie);
        }
       
        public ActionResult SendMail(){
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("ciupiciupa98@gmail.com");
           // mail.To.Add("raulhosu98@yahoo.com");
            mail.Subject = "Test Mail";
            mail.Body = "Thanks for booking!";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ciupiciupa98@gmail.com", "raca1234");
            SmtpServer.EnableSsl = true;

            //SmtpServer.Send(mail);
            return View();
        }
       
    }
}