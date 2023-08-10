namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Data.Models.Enums;
	using CarRentalSystem.Services.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.Areas.Service.ViewModels.Service;
	using CarRentalSystem.Web.Infrastructure.Extensions;
	using CarRentalSystem.Web.ViewModels.Car;
	using CarRentalSystem.Web.ViewModels.Make;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Cors.Infrastructure;
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

			try
			{
				BlogDetailsViewModel viewModel = await this.blogService
					.GetForDetailsByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		public async Task<IActionResult> Add()
		{
			BlogFormModel formModel = new BlogFormModel();

			return this.View(formModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(BlogFormModel formModel)
		{
			if (!ModelState.IsValid)
			{
				return View(formModel);
			}

			try
			{
				string carId =
					await blogService.CreateAndReturnIdAsync(formModel, this.User.GetId()!);

				TempData[SuccessMessage] = "Blog was added successfully!";

				return RedirectToAction("Detail", "Blog", new { id = carId });
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new blog!");

				return View(formModel);
			}
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("All", "Blog");
		}

	}
}
