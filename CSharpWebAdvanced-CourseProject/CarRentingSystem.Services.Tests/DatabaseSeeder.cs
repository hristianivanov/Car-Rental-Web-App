namespace CarRentingSystem.Services.Tests
{
	using CarRentalSystem.Data;
	using CarRentalSystem.Data.Models;

	public static class DatabaseSeeder
	{
		public static void SeedDatabase(CarRentingDbContext dbContext)
		{
			SeedUsers(dbContext);
			SeedCars(dbContext);

			dbContext.SaveChanges();
		}

		private static void SeedUsers(CarRentingDbContext dbContext)
		{
			var renter = new User
			{
				Id = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
				UserName = "testrenter",
				NormalizedUserName = "TESTRENTER",
				Email = "testuser@gmail.com",
				NormalizedEmail = "TESTUSER@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = "your_password_hash_here",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
				FirstName = "Test",
				LastName = "Renter"
			};
			var user = new User
			{
				Id = Guid.Parse("b792974e-1529-4167-8610-5c0fc4d94659"),
				UserName = "testuser",
				NormalizedUserName = "TESTUSER",
				Email = "testuser@gmail.com",
				NormalizedEmail = "TESTUSER@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = "your_password_hash_here",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
				FirstName = "Test",
				LastName = "User"
			};

			dbContext.Users.Add(user);
			dbContext.Users.Add(renter);
		}

		private static void SeedCars(CarRentingDbContext dbContext)
		{
			var cars = new List<Car>
			{
				new Car
				{
					Id = Guid.Parse("179062a5-98aa-43cf-95ec-8f3fa3b99bb8"),
					MakeId = 1,
					Model = "TestCar1",
					PricePerDay = 10,
					FuelAmount = 10,
					Acceleration = 10,
					BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
					Consumption = 10,
					CreatedOn = new DateTime(2019,8,20),
					EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
					HorsePower = 10,
					ImageUrl = "testcar1.png",
					IsActive = true,
					Mileage = 10,
					Range = 10,
					RenterId = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
					PassengerSeats = 5,
					Safety = 5,
					TopSpeed = 10,
					Year = 2019,
					Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
				},
				new Car
				{
					Id = Guid.Parse("d55c5de2-384c-4ffa-b830-8db7a8c17391"),
					MakeId = 1,
					Model = "TestCar2",
					PricePerDay = 10,
					FuelAmount = 10,
					Acceleration = 10,
					BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
					Consumption = 10,
					CreatedOn = new DateTime(2019,8,20),
					EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
					HorsePower = 10,
					ImageUrl = "testcar2.png",
					IsActive = true,
					Mileage = 10,
					Range = 10,
					PassengerSeats = 5,
					Safety = 5,
					TopSpeed = 10,
					Year = 2019,
					Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
				},
				new Car
				{
					Id = Guid.Parse("dea91954-4149-4e46-85ca-59be3fe1e7c9"),
					MakeId = 1,
					Model = "TestCar3",
					PricePerDay = 10,
					FuelAmount = 10,
					Acceleration = 10,
					BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
					Consumption = 10,
					CreatedOn = new DateTime(2015,8,20),
					EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
					HorsePower = 10,
					ImageUrl = "testcar3.png",
					IsActive = false,
					Mileage = 10,
					Range = 10,
					PassengerSeats = 5,
					Safety = 5,
					TopSpeed = 10,
					Year = 2019,
					Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
				},
				new Car
				{
					Id = Guid.Parse("7aed2a88-e55e-42a8-bef8-b421cdae4e2a"),
					MakeId = 1,
					Model = "TestCar4",
					PricePerDay = 10,
					FuelAmount = 10,
					Acceleration = 10,
					BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
					Consumption = 10,
					CreatedOn = new DateTime(2015,8,20),
					EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
					HorsePower = 10,
					ImageUrl = "testcar4.png",
					IsActive = false,
					Mileage = 10,
					Range = 10,
					PassengerSeats = 5,
					Safety = 5,
					TopSpeed = 10,
					Year = 2019,
					Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
				},
			};

			dbContext.Cars.AddRange(cars);
		}
	}
}
