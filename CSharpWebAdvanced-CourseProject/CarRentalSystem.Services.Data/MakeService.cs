namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;
	using Interfaces;

	public class MakeService : IMakeService
	{
		private readonly CarRentingDbContext _context;

		public MakeService(CarRentingDbContext context)
		{
			_context = context;
		}

		public async Task<bool> MakeExiststByNameAsync(string make)
		{
			bool exists = await this._context
				.Makes
				.AnyAsync(m => m.Name.ToLower() == make.ToLower());

			return exists;
		}

		public async Task<int> CreateMakeAsync(string make)
		{
			Make model = new Make()
			{
				Name = make,
			};

			await this._context.Makes.AddAsync(model);
			await this._context.SaveChangesAsync();

			return model.Id;
		}

		public async Task<int> GetIdByMakeNameAsync(string make)
		{
			Make? model = await this._context
				.Makes
				.FirstOrDefaultAsync(m => m.Name.ToLower() == make.ToLower());

			return model.Id;
		}
	}
}
