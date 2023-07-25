namespace CarRentalSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using CarRentalSystem.Data;
    using CarRentalSystem.Data.Models;
    using Interfaces;
    using Web.ViewModels.Make;

    public class MakeService : IMakeService
    {
        private readonly CarRentingDbContext _context;

        public MakeService(CarRentingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> MakeExistsByNameAsync(string make)
        {
            bool exists = await this._context
                .Makes
                .AnyAsync(m =>
                    m.Name.Equals(make, StringComparison.OrdinalIgnoreCase));

            return exists;
        }

        public async Task<MakeViewModel?> GetMakeByNameAsync(string name)
        {
            Make? model = await this._context
                .Makes
                .FirstOrDefaultAsync(m =>
                    m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return new MakeViewModel()
            {
                Id = model!.Id,
                Name = name,
            };
        }

        public async Task CreateMakeAsync(string make)
        {
            Make model = new Make()
            {
                Name = make,
            };

            await this._context.Makes.AddAsync(model);
            await this._context.SaveChangesAsync();
        }

        public async Task<int> GetMakeIdOrCreateMakeAsync(string make)
        {
            Make? model = await this._context
                .Makes
                .FirstOrDefaultAsync(m =>
                    m.Name.Equals(make, StringComparison.OrdinalIgnoreCase));

            if (model == null)
            {
                model = new Make()
                {
                    Name = make
                };

                await this._context.Makes.AddAsync(model);
                await this._context.SaveChangesAsync();
            }

            return model.Id;
        }

    }
}
