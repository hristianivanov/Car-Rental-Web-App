namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Make;

	public interface IMakeService
	{
		Task CreateMakeAsync(MakeFormModel formModel);
		Task CreateMakeAsync(string make);
		Task<int> GetMakeIdOrCreateMakeAsync(string make);
		Task<bool> MakeExistsByNameAsync(string make);
		Task<MakeViewModel?> GetMakeByNameAsync(string name);
		Task<MakeViewModel> CreateMakeAndGetAsync(string name);
	}
}
