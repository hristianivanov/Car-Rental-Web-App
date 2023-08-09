namespace CarRentalSystem.Services.Data
{
	using CarRentalSystem.Data;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using Web.ViewModels.Rent;

	public class RentService : IRentService
	{
		private readonly CarRentingDbContext context;

		public RentService(CarRentingDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<RentViewModel>> AllAsync()
		{
			IEnumerable<RentViewModel> allRents = await this.context
				.Cars
				.Include(c => c.Renter)
				.Where(c => c.RenterId.HasValue)
				.Select(c => new RentViewModel()
				{
					Id = c.Id.ToString(),
					Model = c.Model,
					RenterFullName = c.Renter!.FirstName + ' ' + c.Renter.LastName,
					ImageUrl = c.ImageUrl,
					RenterEmail = c.Renter.Email
				})
				.ToArrayAsync();

			return allRents;
		}
	}
}
