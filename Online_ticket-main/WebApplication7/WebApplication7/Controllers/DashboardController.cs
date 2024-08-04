using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.AspNetCore.Http;

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
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string email , string password)
        {

            var result = conn.Users.Any(x => x.Email == email && x.Password == password);
            if (result)
            {
                var data = conn.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                return RedirectToAction("AdminIndex");
            }
            return View();
        }
    }
}
