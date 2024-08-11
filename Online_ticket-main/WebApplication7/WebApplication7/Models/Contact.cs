using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Textarea { get; set; }

        public Contact(int id, string username ,string email ,string textarea)
        {
            Id = id;
			Username = username;
			Email = email;
			Textarea = textarea;

		}
	}
}
