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

            return View();
        }

		// Trip request form view
		public IActionResult TripRequest()
		{
			ViewBag.PickupLocations = _context.Locations.ToList();
			ViewBag.DropoffLocations = _context.Locations.ToList();
			return View();
		}

		// Handle form submission for trip requests
		[HttpPost]
		public IActionResult SearchTrips(TripRequest request)
		{
			// You can add more complex validation and processing here if needed

			// Store search criteria in TempData or ViewData for the list view
			TempData["PickupLocation"] = request.PickupLocation;
			TempData["DropoffLocation"] = request.DropoffLocation;
			TempData["PickupDate"] = request.PickupDate.ToString("yyyy-MM-dd");
			TempData["DropoffDate"] = request.DropoffDate.ToString("yyyy-MM-dd");
			TempData["PickupTime"] = request.PickupTime.ToString(@"hh\:mm");

			// Redirect to the list view with the search results
			return RedirectToAction("List");
		}

		// List view to display search results
		public IActionResult List()
		{
			// Retrieve search criteria from TempData
			var pickupLocationName = TempData["PickupLocation"] as string;
			var dropoffLocationName = TempData["DropoffLocation"] as string;
			var pickupDate = DateTime.Parse(TempData["PickupDate"] as string);
			var dropoffDate = DateTime.Parse(TempData["DropoffDate"] as string);
			var pickupTime = TimeSpan.Parse(TempData["PickupTime"] as string);

			// Fetch the pickup and dropoff locations from the database
			var pickupLocation = _context.Locations
				.FirstOrDefault(l => l.Name == pickupLocationName);

			var dropoffLocation = _context.Locations
				.FirstOrDefault(l => l.Name == dropoffLocationName);

			if (pickupLocation == null || dropoffLocation == null)
			{
				// Handle the case where one or both locations are not found
				ViewBag.Message = "One or both locations were not found.";
				return View(new List<Trip>()); // Return an empty list or handle as appropriate
			}

			// Fetch trips based on the location IDs and other search criteria
			var trips = _context.Trips
				.Where(t => t.PickupLocationId == pickupLocation.Id
							&& t.DropoffLocationId == dropoffLocation.Id
							&& t.PickupDate.Date == pickupDate.Date
							&& t.DropoffDate.Date == dropoffDate.Date
							&& t.PickupTime == pickupTime)
				.ToList();

			return View(trips);
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
			return View("Contact");
		}
		//[HttpPost]
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
            Users data = new Users(0, username, email, contact, password, 0);
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
            smtp.Credentials = new NetworkCredential("muhammadasfahan689@gmail.com", "zjiv xxvb zvww erlx");
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