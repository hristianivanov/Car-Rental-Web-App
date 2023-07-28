namespace CarRentalSystem.Services.Data.Interfaces
{
	using Models.Car;

	using Web.ViewModels.Car;
	using Web.ViewModels.Home;

	public interface ICarService
	{
		Task<IEnumerable<IndexViewModel>> LastSixCarsAsync();
		Task<IEnumerable<IndexViewModel>> LastCarsAsync(int count);
		Task<int> CreateAndReturnIdAsync(CarFormModel formModel);
		Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel);
		Task<IEnumerable<CarAllViewModel>> AllByUserIdAsync(string userId);
		Task<CarDetailsViewModel> GetDetailsByIdAsync(int carId);
		Task<bool> ExistByIdAsync(int carId);
		Task<CarFormModel> GetCarForEditByIdAsync(int carId);
		Task EditCarByIdAndFormModelAsync(int carId, CarFormModel formModel);
		Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(int carId);
		Task DeleteCarByIdAsync(int carId);
		Task<bool> IsRentedByIdAsync(int carId);
		Task RentCarAsync(int carId, string userId);
		Task<bool> IsRenterByUserWithIdAsync(int carId, string userId);
		Task LeaveCarAsync(int carId);
		//Task CreateAsync(CarFormModel formModel);
		//Task<int> CreateAndReturnIdAsync(CarFormModel model);
	}
}
