namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<bool> UserHasRentsAsync(string userId);
		Task<string> GetFullNameByIdAsync(string userId);
		public Task<AllUsersModel> AllAsync(string searchString);
		Task<bool> IsUserHavePhoneNumber(string userId);
	}
}
