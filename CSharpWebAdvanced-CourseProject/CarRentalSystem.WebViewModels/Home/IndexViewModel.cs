namespace CarRentalSystem.Web.ViewModels.Home
{
	public class IndexViewModel
	{
		public string Id { get; set; }
		public string Make { get; set; } = null!;
		public string Model { get; set; } = null!;
		public string Transmission { get; set; } = null!;
		public string BodyType { get; set; } = null!;
		public string EngineType { get; set; } = null!;
        public decimal PricePerDay { get; set; }
		public int PassengerSeats { get; set; }
		public string ImageUrl { get; set; } = null!;
	}
}
