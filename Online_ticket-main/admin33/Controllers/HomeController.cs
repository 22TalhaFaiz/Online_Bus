using System.Diagnostics;

using admin33.Models;

using Microsoft.AspNetCore.Mvc;

namespace admin33.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult User_detail()
        {
            return View();
        }


    }
}