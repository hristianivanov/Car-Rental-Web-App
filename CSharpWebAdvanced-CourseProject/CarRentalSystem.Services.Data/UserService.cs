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

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            User user = await this.context
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            return user.UserRentals.Any();
        }
    }
}
