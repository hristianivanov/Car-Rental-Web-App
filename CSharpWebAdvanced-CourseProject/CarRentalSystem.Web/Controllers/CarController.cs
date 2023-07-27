namespace CarRentalSystem.Web.Controllers
{
	using CarRentalSystem.Data.Models.Enums;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data.Models.Car;
	using CarRentalSystem.Web.Infrastructure.Extensions;
	using CarRentalSystem.Web.ViewModels.Car;
	using CarRentalSystem.Web.ViewModels.Make;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.CodeAnalysis.CSharp.Syntax;
	using System.Drawing.Imaging;
	using System.Net;
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
			//TODO: save the filter settings in next page
			AllCarsFilteredAndPagedServiceModel serviceModel =
				await this._carService.AllAsync(queryModel);

			queryModel.Cars = serviceModel.Cars;
			queryModel.TotalCarsCount = serviceModel.TotalCarsCount;
			queryModel.Makes = await this._makeService.AllAvailableMakeNamesAsync();

			return this.View(queryModel);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			//TODO: check whether the user is admin
			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return this.RedirectToAction("Index", "Home");
			}

			try
			{
				CarFormModel formModel = new CarFormModel();

				return this.View(formModel);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}
		[HttpPost]
		public async Task<IActionResult> Add(CarFormModel formModel)
		{
			//TODO: check whether the user is admin
			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You need to be an administrator in order to add new car!";

				//TODO:change the redirect to stay in the page where he was...
				return this.RedirectToAction("Index", "Home");
			}

			bool makeExists =
				await this._makeService.MakeExistsByNameAsync(formModel.Make);

			if (!makeExists)
			{
				MakeViewModel make = await this._makeService.CreateMakeAndGetAsync(formModel.Make);
				formModel.MakeId = make.Id;
			}
			else
			{
				var make = await this._makeService.GetMakeByNameAsync(formModel.Make);
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

			if (!this.ModelState.IsValid)
			{
				return this.View(formModel);
			}

			try
			{
				int carId =
					await this._carService.CreateAndReturnIdAsync(formModel);

				TempData[SuccessMessage] = "Car was added successfully!";
				return RedirectToAction("Detail", "Car", new { id = carId });
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty,
					"Unexpected error occurred while trying to add your new car!");

				return this.View(formModel);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Detail(int id)
		{
			bool carExists = await this._carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return this.RedirectToAction("All", "Car");
			}

			try
			{

				CarDetailsViewModel viewModel = await this._carService
					.GetDetailsByIdAsync(id);

				return this.View(viewModel);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

		}

		//idk about the name of the action can be another
		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			List<CarAllViewModel> myCars = new List<CarAllViewModel>();

			string userId = this.User.GetId()!;

			try
			{
				myCars.AddRange(await this._carService.AllByUserIdAsync(userId));

				return this.View(myCars);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			bool carExists = await this._carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return this.RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return this.RedirectToAction("All", "Car");
			}

			try
			{
				CarFormModel formModel = await this._carService
					.GetCarForEditByIdAsync(id);
				return this.View(formModel);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, CarFormModel carModel)
		{
			if (!this.ModelState.IsValid)
			{

				return this.View(carModel);
			}
			bool carExists = await this._carService
				.ExistByIdAsync(id);

			if (!carExists)
			{
				this.TempData[ErrorMessage] = "Car with the provided id does not exist!";

				return this.RedirectToAction("All", "Car");
			}

			bool isAdmin = true;

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = "You must be administrator in order to edit car info!";

				//remake where you to redirect
				return this.RedirectToAction("All", "Car");
			}


			try
			{
				await this._carService.EditCarByIdAndFormModel(id, carModel);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to edit the car!");

				return this.View(carModel);
			}

			return this.RedirectToAction("Detail", "Car", new { id });
		}
		public async Task<IActionResult> Delete(int carId)
		{
			return this.Ok();
		}
		public async Task<IActionResult> Rent()
		{
			return this.Ok();
		}
		public async Task<IActionResult> Leave()
		{
			return this.Ok();
		}

		private IActionResult GeneralError()
		{
			this.TempData[ErrorMessage] = "Unexpected error occurred!";

			return this.RedirectToAction("Index", "Home");
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
