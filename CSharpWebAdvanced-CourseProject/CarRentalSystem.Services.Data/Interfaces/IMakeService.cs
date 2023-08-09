namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Make;

	public interface IMakeService
	{
		Task<bool> MakeExistsByNameAsync(string make);
		Task<MakeViewModel?> GetMakeByNameAsync(string name);
		Task<MakeViewModel> CreateMakeAndGetAsync(string name);
		Task<IEnumerable<string>> AllAvailableMakeNamesAsync();
	}
}
