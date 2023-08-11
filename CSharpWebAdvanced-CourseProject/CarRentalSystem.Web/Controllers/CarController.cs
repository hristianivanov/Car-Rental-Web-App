namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;

	using Data.Models.Enums;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data.Models.Car;
	using Infrastructure.Extensions;
	using ViewModels.Car;
	using ViewModels.Make;
	using ViewModels.Rent;

	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class CarController : Controller
	{
		private readonly ICarService carService;
		private readonly IMakeService makeService;

		private readonly IMemoryCache memoryCache;

		public CarController(ICarService carService, IMakeService makeService,
			IMemoryCache memoryCache)
		{
			this.carService = carService;
			this.makeService = makeService;
			this.memoryCache = memoryCache;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] AllCarsQueryModel queryModel)
		{
			AllCarsFilteredAndPagedServiceModel serviceModel =
				await carService.AllAsync(queryModel);

			queryModel.Cars = serviceModel.Cars;
			queryModel.TotalCarsCount = serviceModel.TotalCarsCount;
			queryModel.Makes = await makeService.AllAvailableMakeNamesAsync();

			return View(queryModel);
		}

		[HttpGet]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Add()
		{
			try
			{
				CarFormModel formModel = new CarFormModel();

				return View(formModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Add(CarFormModel formModel)
		{
			bool makeExists =
				await makeService.MakeExistsByNameAsync(formModel.Make);

			if (!makeExists)
			{
				MakeViewModel make = await makeService.CreateMakeAndGetAsync(formModel.Make);
				formModel.MakeId = make.Id;
			}
			else
			{
				var make = await makeService.GetMakeByNameAsync(formModel.Make);
				formModel.MakeId = make!.Id;
			}

			if (!IsValidEnumValue(formModel.SelectedBodyType))
			{
				ModelState.AddModelError(nameof(BodyType), "Invalid Body Type.");
			}
			if (!IsValidEnumValue(formModel.SelectedEngineType))
			{
				ModelState.AddModelError(nameof(EngineType), "Invalid Engine Type.");
			}
			if (!IsValidEnumValue(formModel.SelectedTransmission))
			{
				ModelState.AddModelError(nameof(Transmission), "Invalid Transmission Type.");
			}

			if (!ModelState.IsValid)
			{
				return View(formModel);
			}

			try
			{
				string carId =
					await carService.CreateAndReturnIdAsync(formModel);

				TempData[SuccessMessage] = "Car was added successfully!";
				return RedirectToAction("Detail", "Car", new { id = carId });
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new car!");

				return View(formModel);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Detail(string id)
		{
			bool carExists = await carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			try
			{
				CarDetailsViewModel viewModel = await carService
					.GetDetailsByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpGet]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				bool carExists = await carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				CarFormModel formModel = await carService
					.GetCarForEditByIdAsync(id);

				return View(formModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Edit(string id, CarFormModel carModel)
		{
			if (!ModelState.IsValid)
			{
				return View(carModel);
			}

			try
			{
				bool carExists = await carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				await carService.EditCarByIdAndFormModelAsync(id, carModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to edit the car!");

				return View(carModel);
			}

			return RedirectToAction("Detail", "Car", new { id });
		}

		[HttpGet]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				bool carExists = await carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				CarPreDeleteDetailsViewModel viewModel =
					await carService.GetCarForDeleteByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = AdminRoleName)]
		public async Task<IActionResult> Delete(string id, CarPreDeleteDetailsViewModel carModel)
		{
			try
			{
				bool carExists = await carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				await carService.SoftDeleteCarByIdAsync(id);

				TempData[WarningMessage] = "The car successfully deleted!";

				return RedirectToAction("All", "Car");
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Rent(string id, RentalFormView viewModel)
		{
			try
			{
				bool carExist = await carService.ExistByIdAsync(id);

				if (!carExist)
				{
					TempData[ErrorMessage] = "Car with provided id does not exist! Please try again!";

					return RedirectToAction("Detail", "Car", new { id });
				}

				bool isCarRented = await carService.IsRentedByIdAsync(id);

				if (isCarRented)
				{
					TempData[ErrorMessage] = "Selected car is already rented by another user! Please select another car.";

					return RedirectToAction("All", "Car");
				}

				viewModel.CarId = id;

				await carService.RentCarAsync(viewModel, User.GetId()!);

				TempData[SuccessMessage] = "You rent successfully your selected car!";
			}
			catch (Exception)
			{
				return GeneralError();
			}

			memoryCache.Remove(RentsCacheKey);

			if (this.User.IsAdmin())
			{
				return RedirectToAction("Detail", "Car", new { id, Area = "" });
			}

			return RedirectToAction("Mine", "Car");
		}



		[HttpPost]
		public async Task<IActionResult> Leave(string id)
		{
			try
			{
				bool carExist = await carService.ExistByIdAsync(id);

				if (!carExist)
				{
					TempData[ErrorMessage] = "Car with provided id does not exist! Please try again!";

					return RedirectToAction("All", "Car");
				}

				bool isCarRented = await carService.IsRentedByIdAsync(id);
				if (!isCarRented)
				{
					TempData[ErrorMessage] = "Selected car is not rented! Please select one of your cars if you wish to leave them.";

					return RedirectToAction("Mine", "Car");
				}

				bool isAdmin = User.IsAdmin();
				bool isCurrUserRenterOfTheCar = await carService.IsRenterByUserWithIdAsync(id, User.GetId()!);

				if (!isCurrUserRenterOfTheCar && !isAdmin)
				{
					TempData[ErrorMessage] =
						"You must be the renter of the car in order to leave it! Please try again with one of your rented cars if you wish to leave it.";

					return RedirectToAction("Mine", "Car");
				}

				await carService.LeaveCarAsync(id);

				TempData[InformationMessage] = "You left your car successfully!";
			}
			catch (Exception)
			{
				return GeneralError();
			}

			memoryCache.Remove(RentsCacheKey);

			if (User.IsAdmin())
			{
				return RedirectToAction("All", "Rent", new { Area = AdminAreaName });
			}

			return RedirectToAction("Mine", "Car");
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			if (User.IsAdmin())
			{
				return RedirectToAction("Mine", "Car", new { Area = AdminAreaName });
			}

			List<CarAllViewModel> myCars = new List<CarAllViewModel>();

			string userId = User.GetId()!;

			try
			{
				myCars.AddRange(await carService.AllByUserIdAsync(userId));

				return View(myCars);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		private IActionResult GeneralError()
		{
			TempData[ErrorMessage] = "Unexpected error occurred!";

			return RedirectToAction("Index", "Home");
		}

		private bool IsValidEnumValue<TEnum>(TEnum value)
		{
			return Enum.IsDefined(typeof(TEnum), value);
		}
	}
}
