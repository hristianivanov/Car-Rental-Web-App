namespace CarRentalSystem.Web.Areas.Admin.ViewModels.Car
{
	using CarRentalSystem.Web.ViewModels.Car;

	public class DeletedCarViewModel
	{
		public IEnumerable<CarAllViewModel> DeletedCars { get; set; } = null!;
	}
}
