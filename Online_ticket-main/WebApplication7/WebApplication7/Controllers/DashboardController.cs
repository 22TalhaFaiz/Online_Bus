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
            // Fetch data from the database
            var users = _conn.Users.ToList(); // Fetch all users for demonstration
            ViewData["Users"] = users; // Pass the data to the view using ViewData

           
            return View();
        }
        public IActionResult Edit()
        {
            var user = _context.Users.Find();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.User_id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        public IActionResult Delete(int id)
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
    }
}
