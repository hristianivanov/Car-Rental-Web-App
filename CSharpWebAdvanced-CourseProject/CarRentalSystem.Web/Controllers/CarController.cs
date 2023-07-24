namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	public class CarController : Controller
	{
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			return this.View();
		}

		public async Task<IActionResult> Add()
		{
			return this.View();
		}

		public async Task<IActionResult> Detail(int carId)
		{
			return this.View();
		}
    }
}
