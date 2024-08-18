using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
	public class Buses
	{
		[Key]
		public int Bus_id { get; set; }
		public string Bus_number { get; set; }

		public int Capacity { get; set; }
		public string Model { get; set; }
		public string Operator { get; set;}
        public string Bus_image { get; set; }




        public Buses (int bus_id, string bus_number, int capacity, string model, string Operator,string bus_image)
		{
			Bus_id = bus_id;
			Bus_number = bus_number;
			Capacity = capacity;
			Model = model;
			this.Operator = Operator;
            Bus_image = bus_image;



        }
    }

	
	}
