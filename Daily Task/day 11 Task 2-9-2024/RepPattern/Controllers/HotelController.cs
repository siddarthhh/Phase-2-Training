using Microsoft.AspNetCore.Mvc;
using RepoPatternAssignment.Models;
using RepoPatternAssignment.Repository;

namespace RepoPatternAssignment.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotel _ser;

        public HotelController(IHotel ser)
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
        public IActionResult Create( HotelModel hotel) 
        {
            _ser.AddHotel(hotel);
            return RedirectToAction(nameof(Index));

        }
    }
}
