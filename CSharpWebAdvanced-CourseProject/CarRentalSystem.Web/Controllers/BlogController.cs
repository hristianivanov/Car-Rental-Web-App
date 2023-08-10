namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Services.Data.Interfaces;
	using Microsoft.AspNetCore.Mvc;

	using ViewModels.Blog;

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
	}
}
