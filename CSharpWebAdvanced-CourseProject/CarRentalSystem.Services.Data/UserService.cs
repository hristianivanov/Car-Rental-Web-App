using CarRentalSystem.Web.ViewModels.User;

namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using Interfaces;
	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;

	public class UserService : IUserService
	{
		private readonly CarRentingDbContext context;

		public UserService(CarRentingDbContext context)
		{
			this.context = context;
		}
		//TODO:
		public async Task<bool> UserHasRentsAsync(string userId)
		{
			User user = await this.context
				.Users
				.FirstAsync(u => u.Id.ToString() == userId);

			return user.UserRentals.Any();
		}

		public async Task<string> GetFullNameByIdAsync(string userId)
		{
			User? user = await this.context
				.Users
				.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return string.Empty;
			}

			return $"{user.FirstName} {user.LastName}";
		}

		public async Task<IEnumerable<UserViewModel>> AllAsync()
		{
			ICollection<UserViewModel> allUsers = await this.context
				.Users
				.Select(u => new UserViewModel()
				{
					Id = u.Id.ToString(),
					Email = u.Email,
					FullName = u.FirstName + ' ' + u.LastName,
					PhoneNumber = u.PhoneNumber ?? string.Empty,
				})
				.ToListAsync();

			return allUsers;
		}
	}
}
