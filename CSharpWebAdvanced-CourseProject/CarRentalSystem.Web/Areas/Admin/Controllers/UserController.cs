namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.User;

	public class UserController : BaseAdminController
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[Route("User/All")]
		[ResponseCache(Duration = 30)]
		public async Task<IActionResult> All(string searchString)
		{
			AllUsersModel users = await this.userService.AllAsync(searchString);

			return View(users);
		}
	}
}
