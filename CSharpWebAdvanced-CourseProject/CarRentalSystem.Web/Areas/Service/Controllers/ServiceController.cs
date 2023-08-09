namespace CarRentalSystem.Web.Areas.Service.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using CarRentalSystem.Web.Areas.Service.ViewModels.Service;

	public class ServiceController : BaseServiceController
	{
		private readonly ServiceDbContext dbContext;
		public ServiceController(ServiceDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[Route("Service/All")]
		public async Task<IActionResult> All()
		{
			AllServiceViewModel model = new AllServiceViewModel()
			{
				Services = await this.dbContext
					.Services
					.Select(s => new ServiceViewModel()
					{
						Id = s.Id,
						Title = s.Title,
						Text = s.Title,
						ImageUrl = s.ImageUrl,
					})
					.ToArrayAsync()
			};

			return View(model);
		}

		[Route("Service/Detail")]
		public async Task<IActionResult> Detail(int id)
		{
			Data.Model.Service serviceViewModel = await this.dbContext
				.Services
				.FirstAsync(s => s.Id == id);

			ServiceViewModel model = new ServiceViewModel()
			{
				Id = serviceViewModel.Id,
				Title = serviceViewModel.Title,
				Text = serviceViewModel.Text,
				ImageUrl = serviceViewModel.ImageUrl
			};

			return View(model);
		}
	}
}
