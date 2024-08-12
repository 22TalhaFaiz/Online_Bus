using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PickupLocationId { get; set; }

        [ForeignKey("PickupLocationId")]
        public Location PickupLocation { get; set; }

        [Required]
        public int DropoffLocationId { get; set; }

        [ForeignKey("DropoffLocationId")]
        public Location DropoffLocation { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public DateTime DropoffDate { get; set; }

        [Required]
        public TimeSpan PickupTime { get; set; }


    }
}
