using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class MoviesController : ControllerBase
    {
        public IActionResult Index()
        {
            var movies = new CinemaDbContext().Movies;
            return View("Index", movies);
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
