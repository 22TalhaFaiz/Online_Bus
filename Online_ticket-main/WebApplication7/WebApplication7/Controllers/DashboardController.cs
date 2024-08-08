using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static WebApplication7.Data.Application;

namespace WebApplication7.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly connection _conn;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
            _conn = new connection();
        }

        public IActionResult AdminIndex()
        { 
            var users = _conn.Users.ToList(); 
            ViewData["Users"] = users; 
            return View();
        }
        public IActionResult Edit()
        {
           
            return View();
        }




        public IActionResult AdminLogin()
        {
            ViewData["LoginTitle"] = "Admin Login";
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string email, string password, int role)
        {
            var result = _conn.Users.Any(x => x.Email == email && x.Password == password && x.role == role);
            if (result)
            {
                var data = _conn.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.role == role);
                if (data != null)
                {
                    if (data.role == 1)
                    {
                        HttpContext.Session.SetString("abc", data.Username);
                        return RedirectToAction("AdminIndex");
                    }
                }
            }
            ViewData["LoginError"] = "Invalid login attempt.";
            return View();
        }

        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }

        public IActionResult Privacy()
        {
            ViewData["PrivacyPolicy"] = "Your privacy policy content goes here.";
            return View();
        }
        public IActionResult Coantact()
        {
           
            return View();
        }

    }
}
