using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Category
    {
        [Key]
        public int Cat_id { get; set; }
        public string Cat_name { get; set; }
    }

}
