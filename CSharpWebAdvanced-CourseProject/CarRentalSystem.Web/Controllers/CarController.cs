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
		public async Task<IActionResult> Add()
		{
			//TODO: check whether the user is admin
			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return RedirectToAction("Index", "Home");
			}

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
		public async Task<IActionResult> Add(CarFormModel formModel)
		{
			//TODO: check whether the user is admin
			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return RedirectToAction("Index", "Home");
			}

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
				formModel.MakeId = make.Id;
			}

			//TODO: I'm not sure whether that may happen or not ?!?!?
			if (!IsValidEnumValue(formModel.SelectedBodyType))
			{
				ModelState.AddModelError(nameof(BodyType), "Invalid Transmission Type.");
			}
			if (!IsValidEnumValue(formModel.SelectedEngineType))
			{
				ModelState.AddModelError(nameof(EngineType), "Invalid Transmission Type.");
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

		//idk about the name of the action can be another
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


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			bool carExists = await _carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return RedirectToAction("All", "Car");
			}

			try
			{
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
		public async Task<IActionResult> Edit(int id, CarFormModel carModel)
		{
			if (!ModelState.IsValid)
			{

				return View(carModel);
			}
			bool carExists = await _carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return RedirectToAction("All", "Car");
			}


			try
			{
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
		public async Task<IActionResult> Delete(int id)
		{
			bool carExists = await _carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return RedirectToAction("All", "Car");
			}

			try
			{
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
		public async Task<IActionResult> Delete(int id, CarPreDeleteDetailsViewModel carModel)
		{
			bool carExists = await _carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return RedirectToAction("All", "Car");
			}

			try
			{
				await _carService.DeleteCarByIdAsync(id);

				TempData[WarningMessage] = "The car successfully deleted!";
				//remake where you want to redirect
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

			bool isAdmin = true;
			//TODO: my admin will he can rent a car?!?!? if not he will be checked

			try
			{
				await _carService.RentCarAsync(id, User.GetId()!);
			}
			catch (Exception)
			{
				return GeneralError();
			}

			//TODO: somewhere i want
			return RedirectToAction("Mine", "Car");

		}
		public async Task<IActionResult> Leave(int id)
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

			bool isAdmin = true;
			//TODO: my admin will he can rent a car?!?!? if not he will be checked

			bool isCurrUserRenterOfTheCar = await _carService.IsRenterByUserWithIdAsync(id, User.GetId()!);

			if (!isCurrUserRenterOfTheCar)
			{
				TempData[ErrorMessage] =
					"You must be the renter of the car in order to leave it! Please try again with one of your rented cars if you wish to leave it.";

				return RedirectToAction("Mine", "Car");
			}

			try
			{
				await _carService.LeaveCarAsync(id);
			}
			catch (Exception)
			{
				return GeneralError();
			}

			return RedirectToAction("Mine","Car");
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
	}
}
