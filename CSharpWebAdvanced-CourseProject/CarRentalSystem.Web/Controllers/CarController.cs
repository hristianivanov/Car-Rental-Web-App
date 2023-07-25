namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Car;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class CarController : Controller
	{
		private readonly ICarService _carService;
		private readonly IMakeService _makeService;

		public CarController(ICarService carService, IMakeService makeService)
		{
			_carService = carService;
			_makeService = makeService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			return this.View();
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			//TODO: check whether the user is admin
			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return this.RedirectToAction("Index","Home");
			}

			CarFormModel formModel = new CarFormModel();

			return this.View(formModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CarFormModel model)
		{
			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return this.RedirectToAction("Index", "Home");
			}

			bool makeExists = await this._makeService.MakeExiststByNameAsync(model.Make);

			if (!makeExists)
			{
				model.MakeId = await this._makeService.CreateMakeAsync(model.Make);
			}
			else
			{
				model.MakeId = await this._makeService.GetIdByMakeNameAsync(model.Make);
			}

			if (!this.ModelState.IsValid)
			{
				//if you depend on something get the data again cause it's stateless on reload the data ...
				model.MakeId = await this._makeService.CreateMakeAsync(model.Make);

				return this.View(model);
			}

			try
			{
				// add the code that may have errors
			}
			catch (Exception _)
			{
				this.ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new car!");

				//here again refresh the data TODO:think of saving the dropdown...

				return this.View(model);
			}
			//TODO:you can return to detail on the car
			return this.RedirectToAction("All","Car");
		}

		public async Task<IActionResult> Detail(int carId)
		{
			return this.View();
		}
    }
}
