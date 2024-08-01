using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication7.Models;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;


namespace WebApplication7
{
    public class HomeController : Controller
    {
        connection conn = new connection();

        public IActionResult Index()
        {
            TempData["name"] = HttpContext.Session.GetString("abc");
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
		public IActionResult Confirm(int code)
		{
            var codes = Convert.ToInt32(HttpContext.Session.GetString("code"));
            if (codes == code)
            {
                var users = conn.Users.FirstOrDefault(def => def.User_id == Convert.ToInt32("id"));
                users.role = 3;
                conn.SaveChanges();
                return View("Confirm");
            }
            else
            {
                
            return View();
            }
		}

		public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string contact,string password)
        {
            Users data = new Users(0, username, email, contact, password,0);
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

        public void SendEmail(string ToMail , string subject,string body)
        {
            var mail = new MailMessage();
            mail.To.Add(ToMail);
            mail.From = new MailAddress("muhammadasfahan689@gmail.com");
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

			var smtp = new SmtpClient("smtp.gmail.com", 587);
			smtp.Credentials = new NetworkCredential("muhammadasfahan689@gmail.com", "jyzo eciq hqmf ttdx");
			smtp.EnableSsl = true;
			smtp.Send(mail);
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