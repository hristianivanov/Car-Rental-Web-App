namespace CarRentalSystem.Services.Data.Interfaces
{
	public interface IMakeService
	{
		Task<bool> MakeExiststByNameAsync(string make);
		Task<int> CreateMakeAsync(string make);
		Task<int> GetIdByMakeNameAsync(string make);
	}
}
