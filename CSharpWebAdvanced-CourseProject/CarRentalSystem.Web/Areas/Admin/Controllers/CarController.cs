namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarRentalSystem.Services.Data.Interfaces;
    using ViewModels.Car;
	using Infrastructure.Extensions;

	public class CarController : BaseAdminController
	{
		private readonly ICarService carService;

		public CarController(ICarService carService)
		{
			this.carService = carService;
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
	}
}
