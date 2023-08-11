namespace CarRentalSystem.Services.Data.Interfaces
{
	using Models.Car;
	using Web.ViewModels.Rent;
	using Web.ViewModels.Car;
	using Web.ViewModels.Home;

	public interface ICarService
	{
		Task<IEnumerable<IndexViewModel>> LastCarsAsync(int count);
		Task<string> CreateAndReturnIdAsync(CarFormModel formModel);
		Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel);
		Task<IEnumerable<CarAllViewModel>> AllByUserIdAsync(string userId);
		Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId);
		Task<bool> ExistByIdAsync(string carId);
		Task<CarFormModel> GetCarForEditByIdAsync(string carId, bool isActive = true);
		Task EditCarByIdAndFormModelAsync(string carId, CarFormModel formModel, bool isActive = true);
		Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId);
		Task DeleteByIdAsync(string carId);
		Task SoftDeleteCarByIdAsync(string carId);
		Task<bool> IsRentedByIdAsync(string carId);
		Task RentCarAsync(RentalFormView rentalForm, string userId);
		Task<bool> IsRenterByUserWithIdAsync(string carId, string userId);
		Task LeaveCarAsync(string carId);
		Task<IEnumerable<CarAllViewModel>> AllDeletedAsync();
		Task AddDeletedCarByIdAsync(string carId);
	}
}
