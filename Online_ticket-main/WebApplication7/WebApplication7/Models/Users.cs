using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Users
    {
        [Key]
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Email{ get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public int role { get; set; }
       public Users(int user_id, string username, string email, string contact, string password, int role)
        {
            User_id = user_id;
            Username = username;
            Email = email;
            Contact = contact;
            Password = password;
            this.role = role;
        }
    }
}
