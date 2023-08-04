namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

    using CarRentalSystem.Services.Data.Interfaces;
    using static Common.GeneralApplicationConstants;

	public class HomeController : Controller
	{
		private readonly ICarService carService;

		public HomeController(ICarService carService)
		{
			this.carService = carService;
		}

		public async Task<IActionResult> Index()
		{
			var viewModel = await this.carService.LastCarsAsync(LastCarsInCarocel);

			return View(viewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404 || statusCode == 400)
			{
				return this.View("Error404");
			}

			if (statusCode == 401)
			{
				return this.View("Error401");
			}
			return View();
		}
	}
}