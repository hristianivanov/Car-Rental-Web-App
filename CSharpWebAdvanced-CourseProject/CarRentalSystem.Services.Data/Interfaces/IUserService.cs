namespace CarRentalSystem.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<bool> UserHasRentsAsync(string userId);
	}
}
