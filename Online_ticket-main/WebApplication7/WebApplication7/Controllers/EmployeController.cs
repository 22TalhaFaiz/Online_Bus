using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static WebApplication7.Data.Application;

namespace WebApplication7.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly connection _conn;
        private readonly connection2 _connect;


        public EmployeController(ApplicationDbContext context)
        {
            _context = context;
            _conn = new connection();
            _connect = new connection2();

        }
        public IActionResult ContactView()
        {
            var users = _connect.contact_us.ToList();
            return View(users);

        }
        public IActionResult ContactEdit(int id)
        {
            var user = _connect.contact_us.FirstOrDefault(a => a.Id == id);// Example for fetching user
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult ContactEdit(int id, string username, string email, string textarea)
        {
            var edit = _connect.contact_us.FirstOrDefault(a => a.Id == id);// Example for fetching user
            edit.Username = username;
            edit.Email = email;
            edit.Textarea = textarea;


            _connect.SaveChanges();
            return RedirectToAction("ContactView");

        }



        public IActionResult ContactDelete(int id)
        {
            var delete = _connect.contact_us.FirstOrDefault(a => a.Id == id);// Example for fetching user

            _connect.contact_us.Remove(delete);
            _connect.SaveChanges();
            return RedirectToAction("ContactView");

        }


      
        public IActionResult Delete(int id)
        {
            var delete = _context.Users.FirstOrDefault(a => a.User_id == id);// Example for fetching user

            _context.Users.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("View");

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
        public IActionResult Edit(int id, string username, string email, string password, string contact)
        {
            var user = _context.Users.FirstOrDefault(a => a.User_id == id);// Example for fetching user
            user.Username = username;
            user.Email = email;
            user.Password = password;
            user.Contact = contact;

            _context.SaveChanges();
            return RedirectToAction("View");

        }



        public IActionResult EmployeIndex()
        {
            return View();
        }


        public IActionResult EmployeLogin()
        {
            ViewData["LoginTitle"] = "Employe Login";
            return View();
        }

        [HttpPost]
        public IActionResult EmployeLogin(string email, string password, int role)
        {
            var result = _conn.Users.Any(x => x.Email == email && x.Password == password && x.role == role);
            if (result)
            {
                var data = _conn.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.role == role);
                if (data != null)
                {
                    if (data.role == 2)
                    {
                        HttpContext.Session.SetString("abc", data.Username);
                        return RedirectToAction("EmployeIndex");
                    }
                }
            }
            ViewData["LoginError"] = "Invalid login attempt.";
            return View();
        }

        public IActionResult EmployeLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("EmployeLogin");
        }

        public IActionResult Privacy()
        {
            ViewData["PrivacyPolicy"] = "Your privacy policy content goes here.";
            return View();
        }

        public IActionResult EmployeHeader()
        {

            return View();
        }

        public IActionResult View()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Addbus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addbus(string bus_number , int capacity , string model , string Operator)
        {
            Buses data = new Buses(0, bus_number, capacity, model, Operator);
            _conn.Buses.Add(data);
            _conn.SaveChanges();

            return View();
        }
    }
}
