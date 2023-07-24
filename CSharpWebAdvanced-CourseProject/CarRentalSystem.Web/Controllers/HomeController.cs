namespace CarRentalSystem.Web.Controllers
{
	using System.Diagnostics;
	using CarRentalSystem.Services.Data.Interfaces;
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Home;

	public class HomeController : Controller
	{
		private readonly ICarService _carService;

		public HomeController(ICarService carService)
		{
			_carService = carService;
		}

		public async Task<IActionResult> Index()
		{
			var viewModel = await this._carService.LastSixCarsAsync();
			return View(viewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}