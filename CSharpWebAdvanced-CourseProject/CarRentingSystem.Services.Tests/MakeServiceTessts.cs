namespace CarRentingSystem.Services.Tests
{
	using CarRentalSystem.Data.Models;
	using CarRentalSystem.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;

	[TestFixture]
	public class MakeServiceTests
	{
		private DbContextOptions<CarRentingDbContext> dbOptions;
		private CarRentingDbContext dbContext;

		private IMakeService makeService;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
				.UseInMemoryDatabase("CarRentingInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new CarRentingDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.makeService = new MakeService(this.dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task MakeExistsByNameAsync_ShouldReturnTrueForExistingMake()
		{
			var existingMakeName = "Toyota";
			var existingMake = new Make
			{
				Name = existingMakeName
			};
			dbContext.Makes.Add(existingMake);
			await dbContext.SaveChangesAsync();

			var result = await makeService.MakeExistsByNameAsync(existingMakeName);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task MakeExistsByNameAsync_ShouldReturnFalseForNonExistingMake()
		{
			var nonExistingMakeName = "NonExistingMake";

			var result = await makeService.MakeExistsByNameAsync(nonExistingMakeName);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetMakeByNameAsync_ShouldReturnMakeViewModelForExistingMake()
		{
			var existingMakeName = "Toyota";
			var existingMake = new Make
			{
				Name = existingMakeName
			};
			dbContext.Makes.Add(existingMake);
			await dbContext.SaveChangesAsync();

			var result = await makeService.GetMakeByNameAsync(existingMakeName);

			Assert.NotNull(result);
			Assert.AreEqual(existingMakeName, result.Name);
		}

		[Test]
		public async Task GetMakeByNameAsync_ShouldReturnNullForNonExistingMake()
		{
			var nonExistingMakeName = "NonExistingMake";

			var result = await makeService.GetMakeByNameAsync(nonExistingMakeName);

			Assert.Null(result);
		}

		[Test]
		public async Task CreateMakeAndGetAsync_ShouldCreateMakeAndReturnMakeViewModel()
		{
			var newMakeName = "NewMake";

			var result = await makeService.CreateMakeAndGetAsync(newMakeName);

			Assert.NotNull(result);
			Assert.AreEqual(newMakeName, result.Name);

			var createdMake = await this.dbContext
				.Makes
				.FirstOrDefaultAsync(m => m.Name == newMakeName);

			Assert.NotNull(createdMake);
			Assert.AreEqual(newMakeName, createdMake.Name);
		}

		[Test]
		public async Task AllAvailableMakeNamesAsync_ShouldReturnListOfAvailableMakeNames()
		{
			var make1 = new Make() { Name = "Make1" };
			var make2 = new Make() { Name = "Make2" };

			var car1 = new Car()
			{
				Id = Guid.NewGuid(),
				Make = make1,
				IsActive = true,
				Model = "TestCar1",
				PricePerDay = 10,
				FuelAmount = 10,
				Acceleration = 10,
				BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
				Consumption = 10,
				CreatedOn = new DateTime(2019, 8, 20),
				EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
				HorsePower = 10,
				ImageUrl = "testcar1.png",
				Mileage = 10,
				Range = 10,
				RenterId = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
				PassengerSeats = 5,
				Safety = 5,
				TopSpeed = 10,
				Year = 2019,
				Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
			};
			var car2 = new Car()
			{
				Id = Guid.NewGuid(),
				Model = "TestCar1",
				PricePerDay = 10,
				FuelAmount = 10,
				Acceleration = 10,
				BodyType = CarRentalSystem.Data.Models.Enums.BodyType.Sedan,
				Consumption = 10,
				CreatedOn = new DateTime(2019, 8, 20),
				EngineType = CarRentalSystem.Data.Models.Enums.EngineType.Diesel,
				HorsePower = 10,
				ImageUrl = "testcar1.png",
				Mileage = 10,
				Range = 10,
				RenterId = Guid.Parse("4e191a73-e8d4-462d-9803-0400812d86cf"),
				PassengerSeats = 5,
				Safety = 5,
				TopSpeed = 10,
				Year = 2019,
				Transmission = CarRentalSystem.Data.Models.Enums.Transmission.Manual,
				Make = make2,
				IsActive = false,
			};

			this.dbContext.Makes.AddRange(make1, make2);
			this.dbContext.Cars.AddRange(car1, car2);

			dbContext.SaveChanges();

			var result = await makeService.AllAvailableMakeNamesAsync();

			Assert.NotNull(result);
			CollectionAssert.Contains(result, make1.Name);
			CollectionAssert.DoesNotContain(result, make2.Name);
		}
	}
}
