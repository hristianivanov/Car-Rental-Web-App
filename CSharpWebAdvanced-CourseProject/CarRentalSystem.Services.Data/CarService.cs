namespace CarRentalSystem.Services.Data
{
	using Interfaces;
	using CarRentalSystem.Data;
	using Web.ViewModels.Home;
	using Microsoft.EntityFrameworkCore;

	public class CarService : ICarService
	{
		private readonly CarRentingDbContext _context;

		public CarService(CarRentingDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<IndexViewModel>> LastSixCarsAsync()
		{
			IEnumerable<IndexViewModel> lastSixCars = await this._context
				.Cars
				.Include(c => c.Make)
				.OrderByDescending(c => c.Id)
				.Take(6)
				.Select(c => new IndexViewModel
				{
					Id = c.Id,
					Make = c.Make.Name,
					Model = c.Model,
					Transmission = c.Transmission.ToString(),
					BodyType = c.BodyType.ToString(),
					EngineType = c.EngineType.ToString(),
					PricePerDay = c.PricePerDay,
					PassengerSeats = c.PassengerSeats,
					ImageUrl = c.ImageUrl,
				})
				.ToArrayAsync();

			return lastSixCars;
		}
		public async Task<IEnumerable<IndexViewModel>> LastCarsAsync(int count)
		{
			IEnumerable<IndexViewModel> lastCars = await this._context
				.Cars
				.Include(c => c.Make)
				.OrderByDescending(c => c.Id)
				.Take(count)
				.Select(c => new IndexViewModel
				{
					Id = c.Id,
					Make = c.Make.Name,
					Model = c.Model,
					Transmission = c.Transmission.ToString(),
					BodyType = c.BodyType.ToString(),
					EngineType = c.EngineType.ToString(),
					PricePerDay = c.PricePerDay,
					PassengerSeats = c.PassengerSeats,
					ImageUrl = c.ImageUrl,
				})
				.ToArrayAsync();

			return lastCars;
		}
	}
}
