using CarRentalSystem.Data.Models.Enums;
using CarRentalSystem.Services.Data.Models.Car;
using CarRentalSystem.Web.ViewModels.Car;
using CarRentalSystem.Web.ViewModels.Car.Enums;
using CarRentalSystem.Web.ViewModels.User;

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
                .Where(c => c.IsActive)
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
                .Where(c => c.IsActive)
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

        public async Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel)
        {
            IQueryable<Car> carsQuery = this._context
                .Cars
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Make))
            {
                carsQuery = carsQuery
                    .Where(c => c.Make.Name == queryModel.Make);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearString))
            {
                string wildCard = $"%{queryModel.SearString.ToLower()}%";

                carsQuery = carsQuery
                    .Where(c => EF.Functions.Like(c.Model, wildCard) ||
                                EF.Functions.Like(c.Make.Name, wildCard));
            }

            carsQuery = queryModel.Transmission switch
            {
                "Auto" => carsQuery
                    .Where(c => c.Transmission == Transmission.Auto),
                "Manual" => carsQuery
                    .Where(c => c.Transmission == Transmission.Manual),
                _ => carsQuery
            };


            carsQuery = queryModel.CarSorting switch
            {
                CarSorting.Newest => carsQuery
                    .OrderByDescending(c => c.Id),
                CarSorting.Oldest => carsQuery
                    .OrderBy(c => c.Id),
                CarSorting.PriceAscending => carsQuery
                    .OrderBy(c => c.PricePerDay),
                CarSorting.PriceDescending => carsQuery
                    .OrderByDescending(c => c.PricePerDay),
                _ => carsQuery
                 .OrderBy(c => c.RenterId != null)
                 .ThenByDescending(c => c.Id)
            };

            IEnumerable<CarAllViewModel> allCars = await carsQuery
	            .Include(c => c.Rentals)
                .Where(c => c.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id,
                    Make = c.Make.Name,
                    Model = c.Model,
                    Transmission = c.Transmission.ToString(),
                    BodyType = c.BodyType.ToString(),
                    EngineType = c.EngineType.ToString(),
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    PassengerSeats = c.PassengerSeats,
                    IsRented = c.RenterId.HasValue,
                })
                .ToArrayAsync();

            int totalCars = carsQuery.Count();

            return new AllCarsFilteredAndPagedServiceModel()
            {
                TotalCarsCount = totalCars,
                Cars = allCars
            };
        }

        public async Task<IEnumerable<CarAllViewModel>> AllByUserIdAsync(string userId)
        {
            var userRentalIds = await _context
                .UsersRentals
                .Where(ur => ur.CustomerId == Guid.Parse(userId))
                .Select(ur => ur.RentalId)
                .ToListAsync();

            //TODO: show only the rented cars for user

            IEnumerable<CarAllViewModel> allUserCars = await _context.Cars
                .Where(c => c.IsActive &&
                            c.Rentals.Any(r => userRentalIds.Contains(r.Id)))
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id,
                    Make = c.Make.Name,
                    Model = c.Model,
                    Transmission = c.Transmission.ToString(),
                    BodyType = c.BodyType.ToString(),
                    EngineType = c.EngineType.ToString(),
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    PassengerSeats = c.PassengerSeats,
                    IsRented = c.IsActive
                })
                .ToArrayAsync();

            return allUserCars;
        }

        public async Task<bool> IsCarRented(int carId)
        {
            bool isRented = await this._context
                .Rentals
                .AnyAsync(r => r.CarId == carId && 
                               r.EndDate > DateTime.UtcNow);

            return isRented;
        }

        public async Task<CarDetailsViewModel> GetDetailsByIdAsync(int carId)
        {
            Car car = await this._context
                .Cars
                .Include(c => c.Make)
                .Include(c => c.Rentals)
                .ThenInclude(r => r.UserRentals)
                .ThenInclude(ur => ur.User)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id == carId);

            return new CarDetailsViewModel
            {
                Id = car.Id,
                Make = car.Make.Name,
                Model = car.Model,
                Transmission = car.Transmission.ToString(),
                ImageUrl = car.ImageUrl,
                PricePerDay = car.PricePerDay,
                PassengerSeats = car.PassengerSeats,
                IsRented = car.RenterId.HasValue,
            };
        }

        public async Task<bool> ExistByIdAsync(int carId)
        {
            bool result = await this._context
                .Cars
                .Where(c => c.IsActive)
                .AnyAsync(c => c.Id == carId);

            return result;
        }

        public async Task<CarFormModel> GetCarForEditByIdAsync(int carId)
        {
            Car car = await this._context
                .Cars
                .Include(c => c.Make)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id == carId);

            return new CarFormModel
            {
                Make = car.Make.Name,
                Model = car.Model,
                PricePerDay = car.PricePerDay,
                Mileage = car.Mileage!.Value,
                Acceleration = car.Acceleration,
                HorsePower = car.HorsePower,
                TopSpeed = car.TopSpeed,
                Year = car.Year,
                Consumption = car.Consumption,
                Range = car.Range,
                Safety = car.Safety!.Value,
                PassengerSeats = car.PassengerSeats,
                ImageUrl = car.ImageUrl,
                SelectedEngineType = car.EngineType,
                SelectedTransmission = car.Transmission,
                SelectedBodyType = car.BodyType,
            };
        }

        public async Task EditCarByIdAndFormModelAsync(int carId, CarFormModel formModel)
        {
            Car car = await this._context
                .Cars
                .Include(c => c.Make)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id == carId);

            car.Make.Name = formModel.Make;
            car.Model = formModel.Model;
            car.PricePerDay = formModel.PricePerDay;
            car.Mileage = formModel.Mileage;
            car.Acceleration = formModel.Acceleration;
            car.HorsePower = formModel.HorsePower;
            car.TopSpeed = formModel.TopSpeed;
            car.Year = formModel.Year;
            car.Consumption = formModel.Consumption;
            car.Range = formModel.Range;
            car.Safety = formModel.Safety;
            car.PassengerSeats = formModel.PassengerSeats;
            car.ImageUrl = formModel.ImageUrl;
            car.EngineType = formModel.SelectedEngineType;
            car.Transmission = formModel.SelectedTransmission;
            car.BodyType = formModel.SelectedBodyType;

            await this._context.SaveChangesAsync();
        }

        public async Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(int carId)
        {
            Car car = await this._context
                .Cars
                .Include(c => c.Make)
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id == carId);

            return new CarPreDeleteDetailsViewModel
            {
                Make = car.Make.Name,
                Model = car.Model,
                ImageUrl = car.ImageUrl
            };
        }

        public async Task DeleteCarByIdAsync(int carId)
        {
            Car carToDelete = await this._context
                .Cars
                .Where(c => c.IsActive)
                .FirstAsync(c => c.Id == carId);

            carToDelete.IsActive = false;

            await this._context.SaveChangesAsync();
        }

        public async Task<bool> IsRentedByIdAsync(int carId)
        {
            Car car = await this._context
                .Cars
                .FirstAsync(c => c.Id == carId);

            //TODO: remake
            return car.IsActive;
        }

        public async Task RentCarAsync(int carId, string userId)
        {
            Car car = await this._context
                .Cars
                .FirstAsync(c => c.Id == carId);

            //TODO:
            //car.RenterId = Guid.Parse(userId);
            //await this._context.SaveChangesAsync();
        }

        public async Task<bool> IsRenterByUserWithIdAsync(int carId, string userId)
        {
            Car car = await this._context
                .Cars
                .FirstAsync(c => c.Id == carId);
            //TODO: is Rented remake
            return car.IsActive
                   /*  && car.RenterId.ToString() == userId*/;
        }

        public async Task LeaveCarAsync(int carId)
        {
            Car car = await this._context
                .Cars
                .FirstAsync(c => c.Id == carId);

            //TODO:
            //car.RenterId = null;
            //await this._context.SaveChangesAsync();
        }
    }
}
