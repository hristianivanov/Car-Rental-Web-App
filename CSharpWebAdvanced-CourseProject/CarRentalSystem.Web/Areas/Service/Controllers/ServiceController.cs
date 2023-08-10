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
	using CarRentalSystem.Services.Data;
	using CarRentalSystem.Web.ViewModels.Car;

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

		[HttpGet]
		[Route("Service/Edit/{id}")]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Edit(int id)
		{
			//bool carExists = await carService
			//	.ExistByIdAsync(id);

			//if (!carExists)
			//{
			//	TempData[ErrorMessage] = "Car with the provided id does not exist!";

			//	return RedirectToAction("All", "Car");
			//}

			Service service = await this.dbContext
				.Services
				.FirstAsync(x => x.Id == id);

			ServiceFormModel formModel = new ServiceFormModel()
			{
				Title = service.Title, 
				Text = service.Text,
				ImageUrl = service.ImageUrl,
			};

			return View(formModel);
		}

		[HttpPost]
		[Route("Service/Edit/{id}")]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Edit(int id, ServiceFormModel formModel)
		{
			if (!ModelState.IsValid)
			{
				return View(formModel);
			}

			//bool carExists = await carService
			//	.ExistByIdAsync(id);

			//if (!carExists)
			//{
			//	TempData[ErrorMessage] = "Car with the provided id does not exist!";

			//	return RedirectToAction("All", "Car");
			//}

			Service service = await this.dbContext
				.Services
				.FirstAsync (x => x.Id == id);

			service.Title = formModel.Title;
			service.Text = formModel.Text;
			service.ImageUrl = formModel.ImageUrl;

			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Detail", "Service", new { Area = "Service" , id });
		}

		[HttpPost]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Delete(int id)
		{
			Service serviceToDelete = await this.dbContext
				.Services
				.FirstAsync(c => c.Id == id);

			this.dbContext.Services.Remove(serviceToDelete);
			await this.dbContext.SaveChangesAsync();

			TempData[WarningMessage] = "The selected car was successfully deleted from the DB!";

			return RedirectToAction("All", "Service", new { Area = "Service" });
		}
	}
}
