using CarRentalSystem.Web.ViewModels.User;

namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using Interfaces;
	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;
	using CarRentalSystem.Data.Models.Enums;
	using CarRentalSystem.Services.Data.Models.Car;
	using CarRentalSystem.Web.ViewModels.Car.Enums;
	using CarRentalSystem.Web.ViewModels.Car;

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

		public async Task<AllUsersModel> AllAsync(string searchString)
		{
			IQueryable<User> usersQuery = this.context.Users;

			if (!string.IsNullOrEmpty(searchString))
			{
				usersQuery = usersQuery.Where(u =>
					u.FirstName.Contains(searchString) ||
					u.LastName.Contains(searchString) ||
					u.Email.Contains(searchString));
			}

			ICollection<UserViewModel> allUsers = await usersQuery
				.Select(u => new UserViewModel()
				{
					Id = u.Id.ToString(),
					Email = u.Email,
					FullName = u.FirstName + ' ' + u.LastName,
					PhoneNumber = u.PhoneNumber ?? string.Empty,
				})
				.ToListAsync();

			AllUsersModel model = new AllUsersModel()
			{
				Users = allUsers
			};

			return model;
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

		public async Task<bool> IsUserHavePhoneNumber(string userId)
		{
			User user = await this.context
				.Users
				.FirstAsync(u => u.Id.ToString() == userId);

			return user.PhoneNumber != null;
		}
	}
}
