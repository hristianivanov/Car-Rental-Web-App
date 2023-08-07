namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Rent;

	public class RentController : BaseAdminController
	{
		private readonly IRentService rentService;

		public RentController(IRentService rentService)
		{
			this.rentService = rentService;
		}

		[Route("Rent/All")]
		public async Task<IActionResult> All()
		{
			IEnumerable<RentViewModel> allRents = 
				await this.rentService.AllAsync();

			return View(allRents);
		}
	}
}
