using CarRentalSystem.Data.Models;

namespace CarRentalSystem.Services.Data
{
	using CarRentalSystem.Data;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class UserService : IUserService
	{
		private readonly CarRentingDbContext _context;

		public UserService(CarRentingDbContext context)
		{
			_context = context;
		}

		public async Task<bool> UserHasRentsAsync(string userId)
		{
			User user = await this._context
				.Users
				.FirstAsync(u => u.Id.ToString() == userId);

			return user.UserRentals.Any(); 
		}
	}
}
