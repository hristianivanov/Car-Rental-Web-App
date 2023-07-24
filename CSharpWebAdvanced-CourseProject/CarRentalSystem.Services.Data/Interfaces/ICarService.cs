namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Home;

	public interface ICarService
	{
		Task<IEnumerable<IndexViewModel>> LastSixCarsAsync();
		Task<IEnumerable<IndexViewModel>> LastCarsAsync(int count);
	}
}
