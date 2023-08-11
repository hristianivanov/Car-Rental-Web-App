namespace CarRentingSystem.Services.Tests
{
	using CarRentalSystem.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	using CarRentalSystem.Data.Models;

	[TestFixture]
	public class RentServiceTests
	{
		private DbContextOptions<CarRentingDbContext> dbOptions;
		private CarRentingDbContext dbContext;

		private IRentService rentService;
		private string renterId;
		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
				.UseInMemoryDatabase("CarRentingInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new CarRentingDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.rentService = new RentService(this.dbContext);
			renterId = "4e191a73-e8d4-462d-9803-0400812d86cf";
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task AllAsync_ShouldReturnListOfRentsWithRenterInfo()
		{
			var rentedCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.RenterId.ToString() == renterId);

			var renter = await this.dbContext
				.Users
				.FirstAsync(u => u.Id.ToString() == renterId);

			var allRents = await this.dbContext
				.Cars
				.Where(c => c.RenterId.HasValue &&
				            c.IsActive)
				.ToListAsync();

			var result = await rentService.AllAsync();

			Assert.NotNull(result);
			Assert.IsTrue(allRents.Count() == result.Count());
			
			var rent = result.Single(r => r.Model ==  rentedCar.Model);

			Assert.AreEqual(renter.FirstName + " " + renter.LastName, rent.RenterFullName);
			Assert.AreEqual(renter.Email, rent.RenterEmail);
			Assert.AreEqual(rentedCar.ImageUrl, rent.ImageUrl);
		}
	}
}
