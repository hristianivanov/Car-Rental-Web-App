namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Car;
	using Web.ViewModels.Home;

	public interface ICarService
	{
		Task<IEnumerable<IndexViewModel>> LastSixCarsAsync();
		Task<IEnumerable<IndexViewModel>> LastCarsAsync(int count);
		//Task CreateAsync(CarFormModel formModel);
  //      Task<int> CreateAndReturnIdAsync(CarFormModel model);
    }
}
