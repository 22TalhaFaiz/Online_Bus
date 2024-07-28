using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
		public IActionResult Confirm()
		{

			return View();
		}

		public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string contact,string password)
        {
            Users data = new Users(0, username, email, contact, password,3);
            conn.Users.Add(data);
            conn.SaveChanges();
            return View("Login");
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var result = conn.Users.Any(x => x.Email == email && x.Password == password);
            if (result)
            {
                var data = conn.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (data != null)
                {


                    if (data.role == 3)
                    {
                        return RedirectToAction("Confirm");
                    }
                    else
                    {
                        HttpContext.Session.SetString("abc", data.Username);
                        var name = HttpContext.Session.GetString("abc");
                        ViewBag.name = name;
                        return View("Index");
                    }

                }
            }
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