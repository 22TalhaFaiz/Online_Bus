using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using WebApplication7.Models;


namespace WebApplication7
{
    public class HomeController : Controller
    {
        connection conn = new connection();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string password,string contact)
        {
            Users data = new Users(0, username, email, password, contact,3);
            conn.Users.Add(data);
            conn.SaveChanges();
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {

            return View();
        }



        public IActionResult About()
        {
            return View();
        }
        public IActionResult Transport()
        {
            return View();
        }



    }
}