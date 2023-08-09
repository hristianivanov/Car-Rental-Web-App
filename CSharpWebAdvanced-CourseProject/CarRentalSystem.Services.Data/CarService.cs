namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using CarRentalSystem.Data.Models;
	using CarRentalSystem.Data.Models.Enums;
	using CarRentalSystem.Data;
	using Interfaces;
	using Models.Car;
	using Web.ViewModels.Car;
	using Web.ViewModels.Car.Enums;
	using Web.ViewModels.Home;
	using System.ComponentModel.DataAnnotations;

	public class CarService : ICarService
	{
		private readonly CarRentingDbContext context;

		public CarService(CarRentingDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<IndexViewModel>> LastSixCarsAsync()
		{
			IEnumerable<IndexViewModel> lastSixCars = await this.context
				.Cars
				.Where(c => c.IsActive)
				.Include(c => c.Make)
				.OrderByDescending(c => c.CreatedOn)
				.Take(6)
				.Select(c => new IndexViewModel
				{
					Id = c.Id.ToString(),
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
			IEnumerable<IndexViewModel> lastCars = await this.context
				.Cars
				.Where(c => c.IsActive &&
							!c.RenterId.HasValue)
				.Include(c => c.Make)
				.OrderByDescending(c => c.CreatedOn)
				.Take(count)
				.Select(c => new IndexViewModel
				{
					Id = c.Id.ToString(),
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

			await this.context.Cars.AddAsync(car);
			await this.context.SaveChangesAsync();
		}

		public async Task<string> CreateAndReturnIdAsync(CarFormModel model)
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

			await this.context.Cars.AddAsync(car);
			await this.context.SaveChangesAsync();

			return car.Id.ToString();
		}

		public async Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel)
		{
			IQueryable<Car> carsQuery = this.context
				.Cars
				.Where(c => c.IsActive)
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
					.OrderByDescending(c => c.CreatedOn),
				CarSorting.Oldest => carsQuery
					.OrderBy(c => c.CreatedOn),
				CarSorting.PriceAscending => carsQuery
					.OrderBy(c => c.PricePerDay),
				CarSorting.PriceDescending => carsQuery
					.OrderByDescending(c => c.PricePerDay),
				_ => carsQuery
				 .OrderBy(c => c.RenterId != null)
				 .ThenByDescending(c => c.CreatedOn)
			};

			IEnumerable<CarAllViewModel> allCars = await carsQuery
				.Include(c => c.Rentals)
				.Where(c => c.IsActive)
				.Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
				.Take(queryModel.CarsPerPage)
				.Select(c => new CarAllViewModel
				{
					Id = c.Id.ToString(),
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
			var allUserCars = await context
				.Cars
				.Where(c => c.IsActive &&
							c.RenterId.HasValue &&
							c.RenterId.ToString() == userId)
				.Select(c => new CarAllViewModel()
				{
					Id = c.Id.ToString(),
					Make = c.Make.Name,
					Model = c.Model,
					Transmission = c.Transmission.ToString(),
					BodyType = c.BodyType.ToString(),
					EngineType = c.EngineType.ToString(),
					ImageUrl = c.ImageUrl,
					PricePerDay = c.PricePerDay,
					PassengerSeats = c.PassengerSeats,
					IsRented = c.RenterId.HasValue
				})
				.ToArrayAsync();

			return allUserCars;
		}

		public async Task<bool> IsCarRented(string carId)
		{
			bool isRented = await this.context
				.Rentals
				.AnyAsync(r => r.CarId.ToString() == carId &&
							   r.EndDate > DateTime.UtcNow);

			return isRented;
		}

		public async Task<CarDetailsViewModel> GetDetailsByIdAsync(string carId)
		{
			Car car = await this.context
				.Cars
				.Include(c => c.Make)
				.Include(c => c.Rentals)
				.ThenInclude(r => r.UserRentals)
				.ThenInclude(ur => ur.User)
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

			return new CarDetailsViewModel
			{
				Id = car.Id.ToString(),
				Make = car.Make.Name,
				Model = car.Model,
				Transmission = car.Transmission.ToString(),
				ImageUrl = car.ImageUrl,
				PricePerDay = car.PricePerDay,
				PassengerSeats = car.PassengerSeats,
				IsRented = car.RenterId.HasValue,
			};
		}

		public async Task<bool> ExistByIdAsync(string carId)
		{
			bool result = await this.context
				.Cars
				.Where(c => c.IsActive)
				.AnyAsync(c => c.Id.ToString() == carId);

			return result;
		}

		public async Task<CarFormModel> GetCarForEditByIdAsync(string carId)
		{
			Car car = await this.context
				.Cars
				.Include(c => c.Make)
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

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

		public async Task EditCarByIdAndFormModelAsync(string carId, CarFormModel formModel)
		{
			Car car = await this.context
				.Cars
				.Include(c => c.Make)
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

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

			await this.context.SaveChangesAsync();
		}

		public async Task<CarPreDeleteDetailsViewModel> GetCarForDeleteByIdAsync(string carId)
		{
			Car car = await this.context
				.Cars
				.Include(c => c.Make)
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

			return new CarPreDeleteDetailsViewModel
			{
				Make = car.Make.Name,
				Model = car.Model,
				ImageUrl = car.ImageUrl
			};
		}

		public async Task DeleteCarByIdAsync(string carId)
		{
			Car carToDelete = await this.context
				.Cars
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

			carToDelete.IsActive = false;

			await this.context.SaveChangesAsync();
		}

		public async Task<bool> IsRentedByIdAsync(string carId)
		{
			Car car = await this.context
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			return car.RenterId.HasValue;
		}

		public async Task RentCarAsync(string carId, string userId)
		{
			Car car = await this.context
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			car.RenterId = Guid.Parse(userId);
			await this.context.SaveChangesAsync();
		}

		public async Task<bool> IsRenterByUserWithIdAsync(string carId, string userId)
		{
			Car car = await this.context
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			return car.IsActive
				&& car.RenterId.ToString() == userId;
		}

		public async Task LeaveCarAsync(string carId)
		{
			Car car = await this.context
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			car.RenterId = null;
			await this.context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CarAllViewModel>> AllDeletedAsync()
		{
			var allCars = await this.context
				.Cars
				.Where(c => !c.IsActive)
				.Select(c => new CarAllViewModel()
				{
					Id = c.Id.ToString(),
					Make = c.Make.Name,
					Model = c.Model,
					Transmission = c.Transmission.ToString(),
					BodyType = c.BodyType.ToString(),
					EngineType = c.EngineType.ToString(),
					ImageUrl = c.ImageUrl,
					PricePerDay = c.PricePerDay,
					PassengerSeats = c.PassengerSeats,
					IsRented = c.RenterId.HasValue
				})
				.ToArrayAsync();

			return allCars;
		}

		public async Task AddDeletedCarByIdAsync(string carId)
		{
			Car carToDelete = await this.context
				.Cars
				.Where(c => !c.IsActive)
				.FirstAsync(c => c.Id.ToString() == carId);

			carToDelete.IsActive = true;

			await this.context.SaveChangesAsync();
		}
	}
}
