namespace CarRentalSystem.Web.Areas.Admin.ViewModels.Car
{
    using CarRentalSystem.Web.ViewModels.Car;

    public class MyCarsViewModel
    {
        public IEnumerable<CarAllViewModel> AddedCars { get; set; } = null!;
        public IEnumerable<CarAllViewModel> RentedCars { get; set; } = null!;
    }
}
