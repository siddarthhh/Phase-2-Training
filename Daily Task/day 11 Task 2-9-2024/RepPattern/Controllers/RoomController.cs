using Microsoft.AspNetCore.Mvc;
using RepoPatternAssignment.Models;
using RepoPatternAssignment.Repository;

namespace RepoPatternAssignment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _ser;

        public RoomController (IRoom ser)
        {
            _ser = ser;
        }
        public IActionResult Index()
        {
            return View(_ser.GetAll().ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomModel room)
        {
            _ser.AddRoom(room);
            return RedirectToAction(nameof(Index));

        }
    }
}
