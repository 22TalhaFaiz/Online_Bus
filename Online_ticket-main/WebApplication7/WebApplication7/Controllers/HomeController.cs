using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication7.Models;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using WebApplication7.Services;
using Microsoft.EntityFrameworkCore;
using static WebApplication7.Data.Application;

namespace WebApplication7
{

    public class HomeController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly CategoryService _categoryService;

        connection conn = new connection();
        connection2 connect = new connection2();




        // Constructor for dependency injection
        public HomeController(CategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        // Index action method
        public IActionResult Index()
        {
            if (_categoryService == null)
            {
                // Log or handle the situation where _categoryService is null
                return StatusCode(500, "CategoryService is not initialized.");
            }

            var categories = _categoryService.GetCategories();
            ViewBag.categories = categories ?? new List<Category>(); // Initialize to an empty list if null
            TempData["name"] = HttpContext.Session.GetString("abc");
            var data = conn.Route.ToList();

            return View(data);
        }


        [HttpPost]
        public IActionResult SearchTrips(int PickupLocation, int DropoffLocation, DateTime BookDate)
        {
           

            var availableBuses = conn.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Route)
                .Where(s => s.route_id == PickupLocation
                            && s.route_id == DropoffLocation     
                            && s.date == BookDate)
                .Select(s => new
                {
                    s.schedule_id,
                    s.bus_id,
                    Operator = s.Bus.Operator,
                    Route = s.Route.Origin + " to " + s.Route.Destination,
                    s.Departure_time,
                    s.Arrival_time,
                    s.date,
                    s.Price
                })
                .ToList();

            if (!availableBuses.Any())
            {
                TempData["Message"] = "No buses available for the selected criteria.";
                return RedirectToAction("NoResults");
            }

            return View("AvailableBuses", availableBuses);
        }



        public IActionResult Header()
        {
            return View();
        }


    

        public IActionResult Footer()
        {
            return View();
        }
		public IActionResult Contact()
		{
			return View();
		}
		[HttpPost]
       public IActionResult Contact(string username , string email , string textarea )
       {
			Contact data = new Contact(0, username, email,textarea);
			connect.contact_us.Add(data);
			connect.SaveChanges();

		return View();
     }
		
		public IActionResult Confirm(int code)
		{
            var codes = Convert.ToInt32(HttpContext.Session.GetString("code"));
            if (codes == code)
            {
                var users = conn.Users.FirstOrDefault(def => def.User_id == Convert.ToInt32(HttpContext.Session.GetString("id")));
                users.role = 3;
                conn.SaveChanges();
                
            }
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



                    HttpContext.Session.SetString("abc", data.Username);
                    
                    return RedirectToAction("Index");




                }
            }
            return View();
        }


        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string contact, string password)
        {
            Users data = new Users(0, username, email, contact, password, 3);
            conn.Users.Add(data);
            conn.SaveChanges();

            Random code = new Random();
            int otp = code.Next(100000, 999999);

            HttpContext.Session.SetString("code", otp.ToString());
            HttpContext.Session.SetString("id", data.User_id.ToString());



            string body = $"<h2>welcome {username}</h2> <p>confirm code:{otp}</p>";
            SendEmail(email, "check email", body);

            return View("Confirm");
        }

       
        public void SendEmail(string ToEmail, string subject, string body)
        {
            var mail1 = new MailMessage();
            mail1.To.Add(ToEmail);
            mail1.From = new MailAddress("muhammadasfahan689@gmail.com");
            mail1.Subject = subject;
            mail1.Body = body;
            mail1.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("muhammadasfahan689@gmail.com", "jdbu yrqg wcdz hnnk");
            smtp.EnableSsl = true;
            smtp.Send(mail1);
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