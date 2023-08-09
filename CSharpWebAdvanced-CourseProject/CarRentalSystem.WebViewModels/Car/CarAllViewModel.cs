namespace CarRentalSystem.Web.ViewModels.Car
{
	using System.ComponentModel.DataAnnotations;

	public class CarAllViewModel
	{
		public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public string BodyType { get; set; } = null!;
        public string EngineType { get; set; } = null!;
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name = "Daily Price")]
		public decimal PricePerDay { get; set; }
        public int PassengerSeats { get; set; }
		[Display(Name = "Is Rented")]
		public bool IsRented { get; set; }

    }
}
