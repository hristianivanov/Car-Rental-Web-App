namespace CarRentalSystem.Web.Areas.Service.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using CarRentalSystem.Web.Areas.Service.ViewModels.Service;
	using Microsoft.AspNetCore.Authorization;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;
	using Service = Data.Model.Service;

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

			return this.View(model);
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

			return this.View(model);
		}

		[Route("Service/Add")]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Add()
		{
			ServiceFormModel formModel = new ServiceFormModel();

			return this.View(formModel);
		}

		[HttpPost]
		[Route("Service/Add")]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Add(ServiceFormModel formModel)
		{
			if (!ModelState.IsValid)
			{
				return this.View(formModel);
			}
			try
			{
				Service service = new Service()
				{
					Title = formModel.Title,
					Text = formModel.Text,
					ImageUrl = formModel.ImageUrl,
				};

				await this.dbContext.Services.AddAsync(service);
				await this.dbContext.SaveChangesAsync();

				int serviceId = service.Id;

				TempData[SuccessMessage] = "Service was added successfully!";
				return RedirectToAction("Detail", "Service", new { id = serviceId });
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new car!");

				return View(formModel);
			}
		}
	}
}
