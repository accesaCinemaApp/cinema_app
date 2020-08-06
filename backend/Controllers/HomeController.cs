using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.Models;
using System.Net;
using System.Net.Mail;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Sending_email

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Email(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>You booked a movie under the name of: {0} </p><p>Click the link bellow to confirm:</p> " +
                    "<p>{1}</p>"; //further context to be added (ex: movie,seats, etc.)
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.FromEmail));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = "Confirm movie booking";
                string url = Url.Action("index", "home", null, "http"); //takes you to home page; actual confirmation link to be added
                message.Body = string.Format(body, model.FromName, url);
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
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public IActionResult Email()
        {
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }

        #endregion
    }
}
