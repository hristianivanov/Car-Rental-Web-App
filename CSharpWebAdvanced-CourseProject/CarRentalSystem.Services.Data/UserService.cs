﻿namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using Interfaces;
	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;
	using Web.ViewModels.User;

	public class UserService : IUserService
	{
		private readonly CarRentingDbContext context;

		public UserService(CarRentingDbContext context)
		{
			this.context = context;
		}

		public async Task<AllUsersModel> AllAsync(string searchString)
		{
			IQueryable<ApplicationUser> usersQuery = this.context.Users;

			if (!string.IsNullOrEmpty(searchString))
			{
				usersQuery = usersQuery.Where(u =>
					u.FirstName.Contains(searchString) ||
					u.LastName.Contains(searchString) ||
					u.Email.Contains(searchString) ||
					u.PhoneNumber.Contains(searchString));
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

		//TODO:add test
		public async Task<bool> IsUserHavePhoneNumber(string userId)
		{
			ApplicationUser? user = await this.context
				.Users
				.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return false;
			}

			return user.PhoneNumber != null;
		}
	}
}
