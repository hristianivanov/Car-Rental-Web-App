namespace CarRentingSystem.Services.Tests
{
	using CarRentalSystem.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	using CarRentalSystem.Data.Models;

	public class UserServiceTests
	{
		private DbContextOptions<CarRentingDbContext> dbOptions;
		private CarRentingDbContext dbContext;

		private IUserService userService;
		
		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
				.UseInMemoryDatabase("CarRentingInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new CarRentingDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.userService = new UserService(this.dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}


		[Test]
		public async Task AllAsync_ShouldReturnAllUsers_WhenNoSearchString()
		{
			var expectedUsersCount = await this.dbContext
				.Users
				.CountAsync();
		
			var result = await userService.AllAsync(null);
		
			Assert.NotNull(result);
			Assert.IsTrue(expectedUsersCount == result.Users.Count());
		}

		[Test]
		public async Task AllAsync_ShouldReturnFilteredUsers_WhenSearchStringProvided()
		{
			var user1 = new User() { FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "123456789" };
			var user2 = new User() { FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", PhoneNumber = "987654321" };
			var user3 = new User() { FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", PhoneNumber = "555555555" };

			dbContext.Users.AddRange(user1, user2, user3);
			dbContext.SaveChanges();

			var result = await userService.AllAsync("Doe");

			Assert.NotNull(result);
			Assert.AreEqual(2, result.Users.Count());

			var userViewModel1 = result.Users.Single(u => u.FullName == "John Doe");
			var userViewModel2 = result.Users.Single(u => u.FullName == "Jane Doe");

			Assert.AreEqual(user1.Id.ToString(), userViewModel1.Id);
			Assert.AreEqual("john@example.com", userViewModel1.Email);
			Assert.AreEqual("123456789", userViewModel1.PhoneNumber);

			Assert.AreEqual(user2.Id.ToString(), userViewModel2.Id);
			Assert.AreEqual("jane@example.com", userViewModel2.Email);
			Assert.AreEqual("987654321", userViewModel2.PhoneNumber);
		}

	}
}
