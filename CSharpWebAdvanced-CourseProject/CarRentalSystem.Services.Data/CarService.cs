using CarRentalSystem.Data.Models.Enums;
using CarRentalSystem.Web.ViewModels.Car;

namespace CarRentalSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using CarRentalSystem.Data;
    using Interfaces;
    using Web.ViewModels.Home;
    using CarRentalSystem.Data.Models;

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

        public async Task CreateAsync(CarFormModel formModel)
        {
            Car car = new Car
            {
                MakeId = formModel.MakeId,
                Model = formModel.Model,
                BodyType = formModel.SelectedBodyType,
                Transmission = formModel.SelectedTransmission,
                Mileage = formModel.Mileage,
                Acceleration = formModel.Acceleration,
                HorsePower = formModel.HorsePower,
                TopSpeed = formModel.TopSpeed,
                Year = formModel.Year,
                EngineType = formModel.SelectedEngineType,
                Consumption = formModel.Consumption,
                Range = formModel.Range,
                Safety = formModel.Safety,
                PassengerSeats = formModel.PassengerSeats,
                PricePerDay = formModel.PricePerDay,
                ImageUrl = formModel.ImageUrl,
            };

            await this._context.Cars.AddAsync(car);
            await this._context.SaveChangesAsync();
        }

        public async Task<int> CreateAndReturnIdAsync(CarFormModel model)
        {
            Car car = new Car
            {
                MakeId = model.MakeId,
                Model = model.Model,
                BodyType = model.SelectedBodyType,
                Transmission = model.SelectedTransmission,
                Mileage = model.Mileage,
                Acceleration = model.Acceleration,
                HorsePower = model.HorsePower,
                TopSpeed = model.TopSpeed,
                Year = model.Year,
                EngineType = model.SelectedEngineType,
                Consumption = model.Consumption,
                Range = model.Range,
                Safety = model.Safety,
                PassengerSeats = model.PassengerSeats,
                PricePerDay = model.PricePerDay,
                ImageUrl = model.ImageUrl,
            };

            await this._context.Cars.AddAsync(car);
            await this._context.SaveChangesAsync();

            return car.Id;
        }
    }
}
