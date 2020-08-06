using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class CinemaRoomsController : Controller
    {
        public IActionResult Index()
        {
            var cinemaRooms = new CinemaDbContext().CinemaRooms;
            return View("Index", cinemaRooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
