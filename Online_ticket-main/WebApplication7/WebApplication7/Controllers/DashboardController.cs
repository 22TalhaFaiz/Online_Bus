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
        public IActionResult Delete(int id)
        {
            var delete = _context.Users.FirstOrDefault(a => a.User_id == id);// Example for fetching user

            _context.Users.Remove(delete);
            _context.SaveChanges();
            return View("View");

        }

        public IActionResult Edit(int id)
        {
            var user = _context.Users.FirstOrDefault(a => a.User_id == id);// Example for fetching user
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
        [HttpPost]
        public IActionResult Edit(int id ,string username,string email , string password ,string contact)
        {
            var user = _context.Users.FirstOrDefault(a => a.User_id == id);// Example for fetching user
            user.Username = username;
            user.Email = email;
            user.Password = password;
            user.Contact = contact;

            _context.SaveChanges();
            return View("View");

        }



        public IActionResult AdminIndex()
        {
            return View("AdminIndex");
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
       

        public IActionResult View()
        {
			var users = _context.Users.ToList();
			return View(users);
        }

    }
}
