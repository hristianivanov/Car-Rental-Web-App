using CarRentalSystem.Web.ViewModels.User;

namespace CarRentalSystem.Web.ViewModels.Car
{
	public class CarDetailsViewModel : CarAllViewModel
	{
		public UserInfoOnCarViewModel User { get; set; } = null!;
	}
}
