namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.User;

	public interface IUserService
	{
		public Task<AllUsersModel> AllAsync(string searchString);
		Task<bool> IsUserHavePhoneNumber(string userId);
	}
}
