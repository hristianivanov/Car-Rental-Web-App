using Microsoft.Net.Http.Headers;

namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;

	public class ImagesController : Controller
	{
		private readonly IImageService imageService;

		public ImagesController(IImageService imageService)
		{
			this.imageService = imageService;
		}

		[HttpGet]
		public IActionResult Upload() => this.View();

		[HttpPost]
		[RequestSizeLimit(100 * 1024 * 1024)]
		public async Task<IActionResult> Upload(IFormFile[] images)
		{
			if (images.Length > 10)
			{
				this.ModelState.AddModelError("images", "You cannot upload more than 10 images!");
			}

			//if (images.Any(i => i.Length > 10 * 1024 * 1024))
			//{
			//	this.ModelState.AddModelError("images", "You cannot be more than 10 megabytes!");
			//}

			await this.imageService.Process(images.Select(i => new ViewModels.Images.ImageInputModel
			{
				Name = i.FileName,
				Type = i.ContentType,
				Content = i.OpenReadStream()
			}));

			return this.RedirectToAction(nameof(this.Done));
		}

		public async Task<IActionResult> All()
			=> this.View(await this.imageService.GetAllImages());

		public async Task<IActionResult> Thumbnail(string id)
		=> this.ReturnImage(await this.imageService.GetThumbnail(id));

		public async Task<IActionResult> Fullscreen(string id)
			=> this.ReturnImage(await this.imageService.GetFullscreen(id));

		private IActionResult ReturnImage(Stream image)
		{
			var headers = this.Response.GetTypedHeaders();

			headers.CacheControl = new CacheControlHeaderValue
			{
				Public = true,
				MaxAge = TimeSpan.FromDays(30)
			};

			headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

			return this.File(image, "image/jpeg");
		}

		public IActionResult Done() => this.View();
	}
}
