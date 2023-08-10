namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Services.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Car;
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Blog;
	using static Common.NotificationMessagesConstants;
	public class BlogController : Controller
	{
		private readonly IBlogService blogService;

		public BlogController(IBlogService blogService)
		{
			this.blogService = blogService;
		}

		public async Task<IActionResult> All()
		{
			AllBlogViewModel model = new AllBlogViewModel()
			{
				Blogs = await this.blogService.AllAsync()
			};


			return View(model);
		}

		public async Task<IActionResult> Detail(string id)
		{
			bool blogExists = await this.blogService
				.ExistByIdAsync(id);

			if (!blogExists)
			{
				TempData[ErrorMessage] = "Blog with the provided id does not exist!";

				return RedirectToAction("All", "Blog");
			}

			//try
			//{
				BlogDetailsViewModel viewModel = await this.blogService
					.GetForDetailsByIdAsync(id);

				return View(viewModel);
			//}
			//catch (Exception)
			//{
			//	return GeneralError();
			//}
		}
	}
}
