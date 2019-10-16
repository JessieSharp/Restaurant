using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Areas.Identity.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;

        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //_context.Database.EnsureCreated(); //one time use
            return View();
        }

        public IActionResult Contact()
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

        [HttpGet]
        public IActionResult Reservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reservation(ReservationViewModel reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            ViewBag.ReservationResult = true;
            return View();
        }
    }
}
