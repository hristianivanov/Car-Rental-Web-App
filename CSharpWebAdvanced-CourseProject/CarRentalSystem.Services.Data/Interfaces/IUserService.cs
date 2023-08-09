namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<bool> UserHasRentsAsync(string userId);
		Task<string> GetFullNameByIdAsync(string userId);
		Task<IEnumerable<UserViewModel>> AllAsync();
		Task<bool> IsUserHavePhoneNumber(string userId);
	}
}
