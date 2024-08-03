using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class DashboardController : Controller
    {
        connection conn = new connection();
        
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult AdminHeader()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Viewdata()
        {
            return View();
        }
    }
}
