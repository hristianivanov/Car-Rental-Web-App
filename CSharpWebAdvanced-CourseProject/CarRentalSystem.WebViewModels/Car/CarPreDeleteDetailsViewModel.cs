namespace CarRentalSystem.Web.ViewModels.Car
{
	using System.ComponentModel.DataAnnotations;

	public class CarPreDeleteDetailsViewModel
	{
		public string Make { get; set; } = null!;
		public string Model { get; set; } = null!;
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;
	}
}
