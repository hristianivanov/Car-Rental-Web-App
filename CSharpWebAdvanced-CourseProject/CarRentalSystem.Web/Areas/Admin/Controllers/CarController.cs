namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using ViewModels.Car;
	using Infrastructure.Extensions;
	using static Common.NotificationMessagesConstants;
	using static Common.GeneralApplicationConstants;

	public class CarController : BaseAdminController
	{
		private readonly ICarService carService;

		public CarController(ICarService carService)
		{
			this.carService = carService;
		}

		public async Task<IActionResult> Add(string id)
		{
			await carService.AddDeletedCarByIdAsync(id);

			TempData[SuccessMessage] = "The car successfully was added again for the users!";

			return RedirectToAction("Deleted", "Car", new { Area = AdminAreaName });

		}

		public async Task<IActionResult> Mine()
		{
			MyCarsViewModel viewModel = new MyCarsViewModel()
			{
				AddedCars = await this.carService.AllByUserIdAsync(this.User.GetId()!),
				RentedCars = await this.carService.AllByUserIdAsync(this.User.GetId()!)
			};

			return View(viewModel);
		}

		public async Task<IActionResult> Deleted()
		{
			DeletedCarViewModel viewModel = new DeletedCarViewModel()
			{
				DeletedCars = await this.carService.AllDeletedAsync()
			};

			return this.View(viewModel);
		}
	}
}
