namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;
	using Interfaces;
	using Web.ViewModels.Make;

	public class MakeService : IMakeService
	{
		private readonly CarRentingDbContext context;

		public MakeService(CarRentingDbContext context)
		{
			this.context = context;
		}

		public async Task CreateMakeAsync(string name)
		{
			Make model = new Make()
			{
				Name = name,
			};

			await this.context.Makes.AddAsync(model);
			await this.context.SaveChangesAsync();
		}
		public async Task CreateMakeAsync(MakeFormModel formModel)
		{
			Make model = new Make()
			{
				Name = formModel.Name,
				NewInnovation = formModel.NewInnovation,
			};

			await this.context.Makes.AddAsync(model);
			await this.context.SaveChangesAsync();
		}
		public async Task<bool> MakeExistsByNameAsync(string make)
		{
			bool exists = await this.context
				.Makes
				.AnyAsync(m => m.Name.ToLower() == make.ToLower());

			return exists;
		}
		public async Task<MakeViewModel?> GetMakeByNameAsync(string name)
		{
			MakeViewModel? model = await this.context
				.Makes
				.Select(m => new MakeViewModel()
				{
					Id = m.Id,
					Name = m.Name,
				})
				.FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());

			return model;
		}

		public async Task<MakeViewModel> CreateMakeAndGetAsync(string name)
		{
			Make make = new Make()
			{
				Name = name,
			};

			await this.context.Makes.AddAsync(make);
			await this.context.SaveChangesAsync();

			return new MakeViewModel()
			{
				Id = make.Id,
				Name = make.Name,
			};
		}

		public async Task<IEnumerable<string>> AllAvailableMakeNamesAsync()
		{
			IEnumerable<string> allNames = await this.context
				.Makes
				.Include(m => m.Cars)
				.Where(m => m.Cars.Any() && m.Cars.Any(c => c.IsActive))
				.Select(m => m.Name)
				.ToArrayAsync();

			return allNames;
		}

		public async Task<int> GetMakeIdOrCreateMakeAsync(string make)
		{
			Make? model = await this.context
				.Makes
				.FirstOrDefaultAsync(m => m.Name.ToLower() == make.ToLower());

			if (model == null)
			{
				model = new Make()
				{
					Name = make
				};

				await this.context.Makes.AddAsync(model);
				await this.context.SaveChangesAsync();
			}

			return model.Id;
		}

	}
}
