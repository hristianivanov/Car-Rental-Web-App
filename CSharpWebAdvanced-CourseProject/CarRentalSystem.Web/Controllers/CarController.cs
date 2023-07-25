namespace CarRentalSystem.Web.Controllers
{
    using CarRentalSystem.Data.Models.Enums;
    using CarRentalSystem.Services.Data.Interfaces;
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

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return this.View();
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

            CarFormModel formModel = new CarFormModel();

            return this.View(formModel);
        }

		[HttpPost]
		public async Task<IActionResult> Add(CarFormModel formModel)
		{
            //TODO: check whether the user is admin
            bool isAdmin = false;

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

            //Check if that is stateless do i need it...
            if (!this.ModelState.IsValid)
            {
                //model.Transmissions = Enum.GetValues(typeof(Transmission)).Cast<Transmission>().ToHashSet();
                //model.BodyTypes = Enum.GetValues(typeof(BodyType)).Cast<BodyType>().ToHashSet();
                //model.EngineTypes = Enum.GetValues(typeof(EngineType)).Cast<EngineType>().ToHashSet();

                return this.View(formModel);
            }

            try
            {
                //model.Transmissions = Enum.GetValues(typeof(Transmission)).Cast<Transmission>().ToHashSet();
                //model.BodyTypes = Enum.GetValues(typeof(BodyType)).Cast<BodyType>().ToHashSet();
                //model.EngineTypes = Enum.GetValues(typeof(EngineType)).Cast<EngineType>().ToHashSet();

                //TODO: create car method and return carId 
                int carId =
                    await this._carService.CreateAndReturnIdAsync(formModel);

                TempData[SuccessMessage] = "Car was added successfully!";
                return RedirectToAction("Detail", "Car", new { id = carId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to add your new car!");

                //here again refresh the data TODO:think of saving the dropdown...

                return this.View(formModel);
            }

            //TODO:you can return to detail on the car
            return this.RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> Detail(int carId)
        {
            return this.View();
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
