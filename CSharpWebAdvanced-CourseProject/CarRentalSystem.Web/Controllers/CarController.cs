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
			return View();
		}

		public async Task<IActionResult> Add()
		{
			return View();
		}
    }
}
