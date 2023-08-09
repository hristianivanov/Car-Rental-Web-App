namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Car;
	using ViewModels.Car;
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

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			CarFormModel formModel = await carService
				.GetCarForEditByIdAsync(id, false);

			return this.View(formModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, CarFormModel carModel)
		{
			if (!ModelState.IsValid)
			{
				return View(carModel);
			}

			await carService.EditCarByIdAndFormModelAsync(id, carModel, false);

			return RedirectToAction("Deleted", "Car", new { Area = AdminAreaName });
		}

		[HttpGet]
		public async Task<IActionResult> Deleted()
		{
			DeletedCarViewModel viewModel = new DeletedCarViewModel()
			{
				DeletedCars = await this.carService.AllDeletedAsync()
			};

			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			await this.carService.DeleteByIdAsync(id);

			TempData[WarningMessage] = "The selected car was successfully deleted from the DB!";

			return RedirectToAction("Deleted", "Car", new { Area = AdminAreaName });
		}
	}
}
