using Asg_1_HotelBooking_AspMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asg_1_HotelBooking_AspMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private static List<HotelBooking> hotelBookings = new List<HotelBooking>();

        public IActionResult Index()
        {
            //var hotelBooking = new HotelBooking();
            return View(hotelBookings);
        }
        public IActionResult Booking()
        {
            var hotel= new HotelBooking();
            return View(hotel);
        }
        public IActionResult Bookings(HotelBooking hb)
        {
            hotelBookings.Add(hb);
            return RedirectToAction(nameof(Index));
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
    }
}