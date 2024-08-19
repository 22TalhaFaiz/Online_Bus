using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Route
    {
        [Key]
        public int route_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Origin { get; set; }

        [Required]
        [StringLength(50)]
        public string Destination { get; set; }

        [Required]
        public int Distance { get; set; }
    }
}
