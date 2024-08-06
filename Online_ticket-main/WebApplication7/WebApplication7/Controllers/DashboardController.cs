using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();

            return View("AdminLogin");
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string email , string password , int role)
        {
          
            var result = conn.Users.Any(x => x.Email == email && x.Password == password && x.role == 1 );
            if (result)
            {
                var data = conn.Users.Where(x => x.Email == email && x.Password == password && x.role == 1).FirstOrDefault();
                if (data != null)
                {


                    if (data.role == 1)
                    {
                        HttpContext.Session.SetString("abc", data.Username);
                        return RedirectToAction("AdminIndex");
                    }

                        





                }
            }
            return View();
        }
    }
}
