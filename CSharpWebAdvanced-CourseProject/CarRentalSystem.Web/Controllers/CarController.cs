namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Web.ViewModels.Car;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class CarController : Controller
	{
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			return this.View();
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			//check whether the user is admin
			bool isAdmin = false;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return this.RedirectToAction("Index","Home");
			}

			CarFormModel formModel = new CarFormModel();

			return this.View(formModel);
		}

		public async Task<IActionResult> Detail(int carId)
		{
			return this.View();
		}
    }
}
