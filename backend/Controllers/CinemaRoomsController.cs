using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class CinemaRoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("CinemaRooms/Details/{roomID:int}")]
        public IActionResult Details(int roomID)
        {
            ViewData["roomID"] = roomID;
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [Route("CinemaRooms/Edit/{roomID:int}")]
        public IActionResult Edit(int roomID)
        {
            ViewData["roomID"] = roomID;
            return View();
        }

        [Route("CinemaRooms/Delete/{roomID:int}")]
        public IActionResult Delete(int roomID)
        {
            ViewData["roomID"] = roomID;
            return View();
        }
    }
}
