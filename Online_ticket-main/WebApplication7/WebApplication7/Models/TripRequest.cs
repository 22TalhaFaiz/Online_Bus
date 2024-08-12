namespace WebApplication7.Models
{
	public class TripRequest
	{
		public string PickupLocation { get; set; }
		public string DropoffLocation { get; set; }
		public DateTime PickupDate { get; set; }
		public DateTime DropoffDate { get; set; }
		public TimeSpan PickupTime { get; set; }


	}
}
