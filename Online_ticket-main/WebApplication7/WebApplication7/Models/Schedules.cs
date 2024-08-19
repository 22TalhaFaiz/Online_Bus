using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Schedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int schedule_id { get; set; }

        [ForeignKey("Bus")]
        public int bus_id { get; set; }
        public Buses Bus { get; set; }

        [ForeignKey("Route")]
        public int route_id{ get; set; }
        public Route Route { get; set; }

        [ForeignKey("Location")]
        public int location_id { get; set; }
        public Location Location { get; set; }



        [Required]
        public TimeSpan Departure_time { get; set; }

        [Required]
        public TimeSpan Arrival_time { get; set; }

        [Required]
        public DateTime date { get; set; }

        public string Price { get; set; }
    }
}
