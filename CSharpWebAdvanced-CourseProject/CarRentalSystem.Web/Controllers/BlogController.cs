namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using Infrastructure.Extensions;
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

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool blogExists = await blogService
					.ExistByIdAsync(id);

				if (!blogExists)
				{
					TempData[ErrorMessage] = "Blog with the provided id does not exist!";

					return RedirectToAction("All", "Blog");
				}

				bool isAdmin = User.IsAdmin();
				bool isCurrUserCreatorOfTheBlogPost = await blogService.IsCreaterWithIdAsync(id, User.GetId()!);

				if (!isCurrUserCreatorOfTheBlogPost && !isAdmin)
				{
					TempData[ErrorMessage] =
						"You must be the creator of the post in order to edit it!";

					return RedirectToAction("Detail", "Blog", new { id });
				}

				BlogFormModel formModel = await blogService
					.GetBlogForEditByIdAsync(id);

				return View(formModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, BlogFormModel blogModel)
		{
			if (!ModelState.IsValid)
			{
				return View(blogModel);
			}

			try
			{
				bool blogExists = await blogService
					.ExistByIdAsync(id);

				if (!blogExists)
				{
					TempData[ErrorMessage] = "Blog with the provided id does not exist!";

					return RedirectToAction("All", "Blog");
				}

				await blogService.EditBlogByIdAndFormModelAsync(id, blogModel);

				this.TempData[InformationMessage] = "Blog post was edited successfully";
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to edit the blog!");

				return View(blogModel);
			}

			return RedirectToAction("Detail", "Blog", new { id });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				bool blogExists = await blogService
					.ExistByIdAsync(id);

				if (!blogExists)
				{
					TempData[ErrorMessage] = "Blog with the provided id does not exist!";

					return RedirectToAction("All", "Blog");
				}

				await this.blogService.DeleteByIdAsync(id);

				TempData[WarningMessage] = "The selected car was successfully deleted from the DB!";

				return RedirectToAction("All", "Blog");
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}


		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("All", "Blog");
		}

	}
}
