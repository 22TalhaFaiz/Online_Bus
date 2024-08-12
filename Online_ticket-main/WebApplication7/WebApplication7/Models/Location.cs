using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
