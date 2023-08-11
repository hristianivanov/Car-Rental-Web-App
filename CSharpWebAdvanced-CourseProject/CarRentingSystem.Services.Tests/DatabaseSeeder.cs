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
			SeedBlogs(dbContext);

			dbContext.SaveChanges();
		}

		private static void SeedBlogs(CarRentingDbContext dbContext)
		{
			
			var blog = new Blog()
			{
				Id = Guid.Parse("3a476437-ec4a-4950-a66b-5aa785234186"),
				Title = "What to Expect When You Rent a Bugatti in Dubai: A Guide for First-Timers",
				Description = "Dubai is renowned for its opulence and luxury, " +
							  "and one of the ultimate symbols of extravagance is cruising through the city in a Bugatti. " +
							  "Known for its sleek design, unmatched power, and jaw-dropping " +
							  "speed, the Bugatti is the epitome of automotive excellence. If you’re considering " +
							  "a Bugatti rental Dubai for the first time, here’s what you can " +
							  "expect from this unforgettable experience.Unparalleled Performance" +
							  "When you opt for a Bugatti hire, you’re not just renting a " +
							  "car; you’re gaining access to a supercar that is in a league of its " +
							  "own. The Bugatti’s engine roars to life, producing an adrenaline-pumping symphony of " +
							  "power. As you press the accelerator, you’ll feel a surge of acceleration that pins " +
							  "you to the seat. With its impressive horsepower and exceptional handling, the Bugatti delivers a driving " +
							  "experience like no other. Be prepared to be amazed by its speed, agility, and " +
							  "the flawless way it hugs the road.Exquisite Design and Craftsmanship" +
							  "Bugatti cars are known for their striking beauty and meticulous attention to detail. From the " +
							  "moment you set eyes on a Bugatti, you’ll be captivated by its elegant curves and aerodynamic " +
							  "profile. The interior is equally breathtaking, with luxurious materials, handcrafted " +
							  "finishes, and state-of-the-art technology. Every inch of a Bugatti exudes sophistication " +
							  "and refinement, making it an absolute pleasure to drive and admire.",
				CreaterId = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
				IsActive = true,
				ImageUrl = "https://localhost:7263/images/blog/image_1.jpg",
				CreatedOn = new DateTime(2019, 10, 29),
			};
			var inActiveBlog = new Blog()
			{
				Id = Guid.Parse("951e54e1-2d76-4f6b-b48f-3c4c186c1d05"),
				Title = "What to Expect When You Rent a Bugatti in Dubai: A Guide for First-Timers",
				Description = "Dubai is renowned for its opulence and luxury, " +
							  "and one of the ultimate symbols of extravagance is cruising through the city in a Bugatti. " +
							  "Known for its sleek design, unmatched power, and jaw-dropping " +
							  "speed, the Bugatti is the epitome of automotive excellence. If you’re considering " +
							  "a Bugatti rental Dubai for the first time, here’s what you can " +
							  "expect from this unforgettable experience.Unparalleled Performance" +
							  "When you opt for a Bugatti hire, you’re not just renting a " +
							  "car; you’re gaining access to a supercar that is in a league of its " +
							  "own. The Bugatti’s engine roars to life, producing an adrenaline-pumping symphony of " +
							  "power. As you press the accelerator, you’ll feel a surge of acceleration that pins " +
							  "you to the seat. With its impressive horsepower and exceptional handling, the Bugatti delivers a driving " +
							  "experience like no other. Be prepared to be amazed by its speed, agility, and " +
							  "the flawless way it hugs the road.Exquisite Design and Craftsmanship" +
							  "Bugatti cars are known for their striking beauty and meticulous attention to detail. From the " +
							  "moment you set eyes on a Bugatti, you’ll be captivated by its elegant curves and aerodynamic " +
							  "profile. The interior is equally breathtaking, with luxurious materials, handcrafted " +
							  "finishes, and state-of-the-art technology. Every inch of a Bugatti exudes sophistication " +
							  "and refinement, making it an absolute pleasure to drive and admire.",
				CreaterId = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
				IsActive = false,
				ImageUrl = "https://localhost:7263/images/blog/image_1.jpg",
				CreatedOn = new DateTime(2019, 10, 29),
			};


			dbContext.Blogs.Add(blog);
		}

		private static void SeedUsers(CarRentingDbContext dbContext)
		{
			var renter = new ApplicationUser
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
			var user = new ApplicationUser
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
