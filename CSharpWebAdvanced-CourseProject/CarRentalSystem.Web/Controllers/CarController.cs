namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Data.Models.Enums;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data.Models.Car;
	using Infrastructure.Extensions;
	using ViewModels.Car;
	using ViewModels.Make;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class CarController : Controller
	{
		private readonly ICarService _carService;
		private readonly IMakeService _makeService;

		public CarController(ICarService carService, IMakeService makeService)
		{
			_carService = carService;
			_makeService = makeService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] AllCarsQueryModel queryModel)
		{
			AllCarsFilteredAndPagedServiceModel serviceModel =
				await _carService.AllAsync(queryModel);

			queryModel.Cars = serviceModel.Cars;
			queryModel.TotalCarsCount = serviceModel.TotalCarsCount;
			queryModel.Makes = await _makeService.AllAvailableMakeNamesAsync();

			return View(queryModel);
		}

		[HttpGet]
		[Authorize(Roles = "Master Administrator")]
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
		[Authorize(Roles = "Master Administrator")]
		public async Task<IActionResult> Add(CarFormModel formModel)
		{
			bool makeExists =
				await _makeService.MakeExistsByNameAsync(formModel.Make);

			if (!makeExists)
			{
				MakeViewModel make = await _makeService.CreateMakeAndGetAsync(formModel.Make);
				formModel.MakeId = make.Id;
			}
			else
			{
				var make = await _makeService.GetMakeByNameAsync(formModel.Make);
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
				int carId =
					await _carService.CreateAndReturnIdAsync(formModel);

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
		public async Task<IActionResult> Detail(int id)
		{
			bool carExists = await _carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			try
			{
				CarDetailsViewModel viewModel = await _carService
					.GetDetailsByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpGet]
		[Authorize(Roles = "Master Administrator")]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				bool carExists = await _carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				CarFormModel formModel = await _carService
					.GetCarForEditByIdAsync(id);

				return View(formModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = "Master Administrator")]
		public async Task<IActionResult> Edit(int id, CarFormModel carModel)
		{
			if (!ModelState.IsValid)
			{
				return View(carModel);
			}

			try
			{
				bool carExists = await _carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				await _carService.EditCarByIdAndFormModelAsync(id, carModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to edit the car!");

				return View(carModel);
			}

			return RedirectToAction("Detail", "Car", new { id });
		}

		[HttpGet]
		[Authorize(Roles = "Master Administrator")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				bool carExists = await _carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				CarPreDeleteDetailsViewModel viewModel =
					await _carService.GetCarForDeleteByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = "Master Administrator")]
		public async Task<IActionResult> Delete(int id, CarPreDeleteDetailsViewModel carModel)
		{
			try
			{
				bool carExists = await _carService
					.ExistByIdAsync(id);

				if (!carExists)
				{
					TempData[ErrorMessage] = "Car with the provided id does not exist!";

					return RedirectToAction("All", "Car");
				}

				await _carService.DeleteCarByIdAsync(id);

				TempData[WarningMessage] = "The car successfully deleted!";

				return RedirectToAction("All", "Car");
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Rent(int id)
		{
			try
			{
				bool carExist = await _carService.ExistByIdAsync(id);

				if (!carExist)
				{
					TempData[ErrorMessage] = "Car with provided id does not exist! Please try again!";

					return RedirectToAction("All", "Car");
				}

				bool isCarRented = await _carService.IsRentedByIdAsync(id);

				if (isCarRented)
				{
					TempData[ErrorMessage] = "Selected car is already rented by another user! Please select another car.";

					return RedirectToAction("All", "Car");
				}

				await _carService.RentCarAsync(id, User.GetId()!);

				TempData[SuccessMessage] = "You rent successfully your selected car!";
			}
			catch (Exception)
			{
				return GeneralError();
			}

			return RedirectToAction("Mine", "Car");
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			try
			{
				bool carExist = await _carService.ExistByIdAsync(id);

				if (!carExist)
				{
					TempData[ErrorMessage] = "Car with provided id does not exist! Please try again!";

					return RedirectToAction("All", "Car");
				}

				bool isCarRented = await _carService.IsRentedByIdAsync(id);
				if (!isCarRented)
				{
					TempData[ErrorMessage] = "Selected car is not rented! Please select one of your cars if you wish to leave them.";

					return RedirectToAction("Mine", "Car");
				}

				bool isCurrUserRenterOfTheCar = await _carService.IsRenterByUserWithIdAsync(id, User.GetId()!);
				bool isAdmin = User.IsAdmin();
				if (!isCurrUserRenterOfTheCar && !isAdmin)
				{
					TempData[ErrorMessage] =
						"You must be the renter of the car in order to leave it! Please try again with one of your rented cars if you wish to leave it.";

					return RedirectToAction("Mine", "Car");
				}

				await _carService.LeaveCarAsync(id);

				TempData[InformationMessage] = "You left your car successfully!";
			}
			catch (Exception)
			{
				return GeneralError();
			}

			return RedirectToAction("Mine", "Car");
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			List<CarAllViewModel> myCars = new List<CarAllViewModel>();

			string userId = User.GetId()!;

			try
			{
				myCars.AddRange(await _carService.AllByUserIdAsync(userId));

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

		#region isimagevalid method

		//public bool IsImageValid(string imageUrl)
		//{
		//    try
		//    {
		//        using (var webClient = new WebClient())
		//        {
		//            // Изтегляне на изображението
		//            byte[] data = webClient.DownloadData(imageUrl);

		//            using (var imageStream = new System.IO.MemoryStream(data))
		//            {
		//                // Опит за зареждане на изображението
		//                using (var image = Image.FromStream(imageStream))
		//                {
		//                    // Проверка дали изображението е валидно според формата на файла
		//                    return image.RawFormat.Guid == ImageFormat.Bmp.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Jpeg.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Png.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Tiff.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Wmf.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Emf.Guid ||
		//                           image.RawFormat.Guid == ImageFormat.Gif.Guid;
		//                }
		//            }
		//        }
		//    }
		//    catch
		//    {
		//        // В случай на грешка, например невалиден URL или друг проблем с изображението
		//        return false;
		//    }
		//}

		#endregion
	}
}
