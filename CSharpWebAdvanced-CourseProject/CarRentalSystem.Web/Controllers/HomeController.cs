namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

    using CarRentalSystem.Services.Data.Interfaces;
    using static Common.GeneralApplicationConstants;
	using Infrastructure.Extensions;

	public class HomeController : Controller
	{
		private readonly ICarService carService;

		public HomeController(ICarService carService)
		{
			this.carService = carService;
		}

		public async Task<IActionResult> Index()
		{
			if (this.User.IsAdmin())
			{
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			var viewModel = await this.carService.LastCarsAsync(LastCarsInCarocel);

			return View(viewModel);
		}

		public IActionResult About()
		{
			return View();
		}

		
		public IActionResult Contact()
		{
			return View();
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