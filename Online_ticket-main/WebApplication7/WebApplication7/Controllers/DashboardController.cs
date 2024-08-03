using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class DashboardController : Controller
    {
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
        public IActionResult User_detail()
        {
            return View();
        }
    }
}
