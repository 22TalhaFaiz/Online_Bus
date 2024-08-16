using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Location
    {
        [Key]
        public int Location_id{ get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
