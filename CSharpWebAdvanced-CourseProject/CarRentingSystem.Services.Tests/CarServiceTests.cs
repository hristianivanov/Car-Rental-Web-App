namespace CarRentingSystem.Services.Tests
{
	using Microsoft.EntityFrameworkCore;

	using CarRentalSystem.Data.Models;
	using CarRentalSystem.Data;
	using CarRentalSystem.Services.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using static DatabaseSeeder;
	using CarRentalSystem.Web.ViewModels.Car;
	using CarRentalSystem.Data.Models.Enums;
	using CarRentalSystem.Web.ViewModels.Car.Enums;
	using static CarRentalSystem.Common.EntityValidationConstants;
	using Car = CarRentalSystem.Data.Models.Car;
	using CarRentalSystem.Web.ViewModels.Rent;

	[TestFixture]
	public class CarServiceTests
	{
		private DbContextOptions<CarRentingDbContext> dbOptions;
		private CarRentingDbContext dbContext;

		private ICarService carService;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
				.UseInMemoryDatabase("CarRentingInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new CarRentingDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.carService = new CarService(this.dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(5)]
		[TestCase(6)]
		public async Task LastCarsAsync_ShouldReturnListOfLastActiveCars_ByGivenNumber(int count)
		{
			var actual = await this.dbContext
				.Cars
				.Where(c => c.IsActive &&
							!c.RenterId.HasValue)
				.OrderByDescending(c => c.CreatedOn)
				.Take(count)
				.ToListAsync();

			var result = await this.carService.LastCarsAsync(count);
			var a = result.Count();
			Assert.IsTrue(actual.Count() == a);
		}

		[Test]
		public async Task CreateAndReturnIdAsync_ShouldAddCar_AndReturnTheNewId()
		{
			var before = await this.dbContext
				.Cars
				.ToListAsync();

			var model = new CarFormModel()
			{
				Model = "test_model",
				Safety = 1,
				PassengerSeats = 1,
				Year = 2020,
				SelectedBodyType = BodyType.Coupe,
				SelectedTransmission = Transmission.Manual,
				SelectedEngineType = EngineType.Electric,
				Range = 1,
				PricePerDay = 1,
				HorsePower = 1,
				ImageUrl = "test.png",
				MakeId = 1,
				Mileage = 1,
				TopSpeed = 1,
				Acceleration = 1,
				Consumption = 1,
			};

			string actualId = await this.carService.CreateAndReturnIdAsync(model);

			var result = await this.dbContext
				.Cars
				.ToListAsync();

			Assert.That(result, Has.Count.EqualTo(before.Count + 1));
			Assert.That(result, Has.Exactly(1)
				.Matches<Car>(car => car.Id.ToString() == actualId));
		}

		[TestCase("invalid")]
		[TestCase("BMW")]
		[TestCase("Audi")]
		public async Task AllAsync_ShouldFilterByMake(string makeToFilter)
		{
			var queryModel = new AllCarsQueryModel
			{
				Make = makeToFilter,
			};

			var result = await carService.AllAsync(queryModel);

			Assert.That(result.Cars, Is.All.Matches<CarAllViewModel>(car => car.Make == makeToFilter));
		}

		[TestCase("")]
		[TestCase("bmw")]
		[TestCase("bMw")]
		[TestCase("BMW")]
		[TestCase("Audi")]
		[TestCase("A5")]
		[TestCase("e60")]
		[TestCase("invalid")]
		public async Task AllAsync_ShouldFilterBySearchString(string searchStringToFilter)
		{
			var queryModel = new AllCarsQueryModel
			{
				SearchString = searchStringToFilter
			};

			var result = await carService.AllAsync(queryModel);

			var filteredCars = dbContext.Cars
				.Where(c => c.IsActive &&
							(c.Model.ToLower().Contains(searchStringToFilter) ||
							 c.Make.Name.ToLower().Contains(searchStringToFilter)))
				.Select(c => c.Id.ToString())
				.ToList();

			Assert.That(result.Cars.Select(c => c.Id), Is.EquivalentTo(filteredCars));
		}

		[TestCase(Transmission.Auto)]
		[TestCase(Transmission.Manual)]
		public async Task AllAsync_ShouldFilterByTransmission(Transmission transmissionToFilter)
		{
			var queryModel = new AllCarsQueryModel
			{
				Transmission = transmissionToFilter.ToString(),
			};

			var result = await carService.AllAsync(queryModel);

			var filteredCars = dbContext.Cars
				.Where(c => c.IsActive && c.Transmission == transmissionToFilter)
				.Select(c => c.Id.ToString())
				.ToList();
			Assert.That(result.Cars.Select(c => c.Id), Is.EquivalentTo(filteredCars));
		}

		[Test]
		public async Task AllAsync_ShouldSortByNewest()
		{
			var queryModel = new AllCarsQueryModel
			{
				CarSorting = CarSorting.Newest
			};

			var result = await carService.AllAsync(queryModel);

			var orderedCars = dbContext.Cars
				.Where(c => c.IsActive)
				.OrderByDescending(c => c.CreatedOn)
				.Select(c => c.Id.ToString())
				.ToList();

			Assert.That(result.Cars.Select(c => c.Id), Is.EqualTo(orderedCars));
		}

		[Test]
		public async Task AllAsync_ShouldSortByPriceAscending()
		{
			var queryModel = new AllCarsQueryModel
			{
				CarSorting = CarSorting.PriceAscending
			};

			var result = await carService.AllAsync(queryModel);

			var orderedCars = dbContext.Cars
				.Where(c => c.IsActive)
				.OrderBy(c => c.PricePerDay)
				.Select(c => c.Id.ToString())
				.ToList();

			Assert.That(result.Cars.Select(c => c.Id), Is.EqualTo(orderedCars));
		}

		[Test]
		public async Task AllAsync_ShouldSortByPriceDescending()
		{
			var queryModel = new AllCarsQueryModel
			{
				CarSorting = CarSorting.PriceDescending,
			};

			var result = await carService.AllAsync(queryModel);

			var orderedCars = dbContext.Cars
				.Where(c => c.IsActive)
				.OrderByDescending(c => c.PricePerDay)
				.Select(c => c.Id.ToString())
				.ToList();

			Assert.That(result.Cars.Select(c => c.Id), Is.EqualTo(orderedCars));
		}

		[TestCase(1, 6)]
		[TestCase(1, 2)]
		[TestCase(2, 6)]
		public async Task AllAsync_ShouldPageResults(int currPage, int carsPerPage)
		{
			var queryModel = new AllCarsQueryModel
			{
				CurrentPage = currPage,
			};

			int expectedCarsPerPage = await this.dbContext
				.Cars
				.Where(c => c.IsActive)
				.Skip((currPage - 1) * carsPerPage)
				.Take(queryModel.CarsPerPage)
				.CountAsync();

			var result = await carService.AllAsync(queryModel);
			int actualCarsPerPage = result.Cars.Count();
			int expectedTotalCarsCount = dbContext.Cars.Count(c => c.IsActive);

			Assert.That(actualCarsPerPage, Is.EqualTo(expectedCarsPerPage));
			Assert.That(result.TotalCarsCount, Is.EqualTo(expectedTotalCarsCount));
		}

		[Test]
		public async Task AllByUserIdAsync_ShouldReturnCorrectCarsForUser()
		{
			string userId = "4e191a73-e8d4-462d-9803-0400812d86cf";

			var result = await carService.AllByUserIdAsync(userId);

			var expectedCarIds = await this.dbContext
				.Cars
				.Where(c => c.IsActive &&
							c.RenterId.HasValue &&
							c.RenterId.ToString() == userId)
				.Select(c => c.Id.ToString())
				.ToListAsync();

			var actualCarIds = result
				.Select(c => c.Id)
				.ToList();

			CollectionAssert.AreEquivalent(expectedCarIds, actualCarIds);
		}

		[Test]
		public async Task AllByUserIdAsync_ShouldReturnEmptyListForNonExistingUser()
		{
			string nonExistingUserId = "non-existing-user-id";

			var result = await carService.AllByUserIdAsync(nonExistingUserId);

			Assert.IsEmpty(result);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnCorrectCarDetails()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			var result = await carService.GetDetailsByIdAsync(carId);

			var expectedCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			Assert.NotNull(result);
			Assert.AreEqual(carId, result.Id);
			Assert.AreEqual(expectedCar.Make.Name, result.Make);
			Assert.AreEqual(expectedCar.Model, result.Model);
			Assert.AreEqual(expectedCar.PricePerDay, result.PricePerDay);
			Assert.AreEqual(expectedCar.RenterId.HasValue, result.IsRented);
			Assert.AreEqual(expectedCar.Transmission.ToString(), result.Transmission);
			Assert.AreEqual(expectedCar.ImageUrl, result.ImageUrl);
			Assert.AreEqual(expectedCar.PassengerSeats, result.PassengerSeats);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldThrowExceptionForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.GetDetailsByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task ExistByIdAsync_ShouldReturnTrueForExistingCar()
		{
			string existingCarId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			bool result = await carService.ExistByIdAsync(existingCarId);

			Assert.True(result);
		}

		[Test]
		public async Task ExistByIdAsync_ShouldReturnFalseForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			bool result = await carService.ExistByIdAsync(nonExistingCarId);

			Assert.False(result);
		}

		[Test]
		public async Task GetCarForEditByIdAsync_ShouldReturnCarForEditing()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			var expectedCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			var result = await carService.GetCarForEditByIdAsync(carId);

			Assert.NotNull(result);
			Assert.AreEqual(expectedCar.Make.Name, result.Make);
			Assert.AreEqual(expectedCar.Model, result.Model);
			Assert.AreEqual(expectedCar.Acceleration, result.Acceleration);
			Assert.AreEqual(expectedCar.Mileage, result.Mileage);
			Assert.AreEqual(expectedCar.Year, result.Year);
			Assert.AreEqual(expectedCar.Range, result.Range);
			Assert.AreEqual(expectedCar.Consumption, result.Consumption);
			Assert.AreEqual(expectedCar.HorsePower, result.HorsePower);
			Assert.AreEqual(expectedCar.ImageUrl, result.ImageUrl);
			Assert.AreEqual(expectedCar.PassengerSeats, result.PassengerSeats);
			Assert.AreEqual(expectedCar.PricePerDay, result.PricePerDay);
			Assert.AreEqual(expectedCar.Safety, result.Safety);
			Assert.AreEqual(expectedCar.BodyType, result.SelectedBodyType);
			Assert.AreEqual(expectedCar.EngineType, result.SelectedEngineType);
			Assert.AreEqual(expectedCar.Transmission, result.SelectedTransmission);
			Assert.AreEqual(expectedCar.TopSpeed, result.TopSpeed);
		}

		[Test]
		public async Task GetCarForEditByIdAsync_ShouldReturnNullForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.GetCarForEditByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task EditCarByIdAndFormModelAsync_ShouldEditCarProperties()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";
			var formModel = new CarFormModel
			{
				Make = "Audi",
				Model = "A3",
				PricePerDay = 100,
				Mileage = 50000,
				Acceleration = 200,
				Consumption = 200,
				HorsePower = 200,
				ImageUrl = "changes.png",
				PassengerSeats = 1,
				Range = 200,
				TopSpeed = 200,
				Safety = 1,
				Year = 2000,
				SelectedBodyType = BodyType.SUV,
				SelectedEngineType = EngineType.Gasoline,
				SelectedTransmission = Transmission.Auto,
			};

			await carService.EditCarByIdAndFormModelAsync(carId, formModel);

			var editedCar = await dbContext.Cars.FindAsync(Guid.Parse(carId));

			Assert.NotNull(editedCar);
			Assert.AreEqual(formModel.Make, editedCar.Make.Name);
			Assert.AreEqual(formModel.Model, editedCar.Model);
			Assert.AreEqual(formModel.PricePerDay, editedCar.PricePerDay);
			Assert.AreEqual(formModel.Mileage, editedCar.Mileage);
			Assert.AreEqual(formModel.Acceleration, editedCar.Acceleration);
			Assert.AreEqual(formModel.Consumption, editedCar.Consumption);
			Assert.AreEqual(formModel.HorsePower, editedCar.HorsePower);
			Assert.AreEqual(formModel.ImageUrl, editedCar.ImageUrl);
			Assert.AreEqual(formModel.PassengerSeats, editedCar.PassengerSeats);
			Assert.AreEqual(formModel.Range, editedCar.Range);
			Assert.AreEqual(formModel.TopSpeed, editedCar.TopSpeed);
			Assert.AreEqual(formModel.Safety, editedCar.Safety);
			Assert.AreEqual(formModel.Year, editedCar.Year);
			Assert.AreEqual(formModel.SelectedBodyType, editedCar.BodyType);
			Assert.AreEqual(formModel.SelectedEngineType, editedCar.EngineType);
			Assert.AreEqual(formModel.SelectedTransmission, editedCar.Transmission);
		}

		[Test]
		public async Task EditCarByIdAndFormModelAsync_ShouldThrowExceptionWithInvalidCarId()
		{
			string nonExistingCarId = "invalid";

			CarFormModel formModel = null;

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.EditCarByIdAndFormModelAsync(nonExistingCarId, formModel);
			});
		}

		[Test]
		public async Task EditCarByIdAndFormModelAsync_ShouldThrowExceptionWithSoftDeletedCar()
		{
			string carId = "dea91954-4149-4e46-85ca-59be3fe1e7c9";

			var formModel = new CarFormModel
			{
				Make = "Audi",
				Model = "A3",
				PricePerDay = 100,
				Mileage = 50000,
				Acceleration = 200,
				Consumption = 200,
				HorsePower = 200,
				ImageUrl = "changes.png",
				PassengerSeats = 1,
				Range = 200,
				TopSpeed = 200,
				Safety = 1,
				Year = 2000,
				SelectedBodyType = BodyType.SUV,
				SelectedEngineType = EngineType.Gasoline,
				SelectedTransmission = Transmission.Auto,
			};

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.EditCarByIdAndFormModelAsync(carId, formModel);
			});
		}

		[Test]
		public async Task GetCarForDeleteByIdAsync_ShouldReturnCorrectCarForDeletion()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			var expectedCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			var result = await carService.GetCarForDeleteByIdAsync(carId);

			Assert.NotNull(result);
			Assert.AreEqual(expectedCar.Make.Name, result.Make);
			Assert.AreEqual(expectedCar.Model, result.Model);
			Assert.AreEqual(expectedCar.ImageUrl, result.ImageUrl);
		}

		[Test]
		public async Task GetCarForDeleteByIdAsync_ShouldReturnNullForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.GetCarForDeleteByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task GetCarForDeleteByIdAsync_ShouldReturnNullForInactiveCar()
		{
			string inactiveCarId = "dea91954-4149-4e46-85ca-59be3fe1e7c9";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.GetCarForDeleteByIdAsync(inactiveCarId);
			});
		}

		[Test]
		public async Task DeleteByIdAsync_ShouldDeleteCarCorrectly()
		{
			string carIdToDelete = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			await carService.DeleteByIdAsync(carIdToDelete);

			var deletedCar = await dbContext
				.Cars
				.FirstOrDefaultAsync(c => c.Id.ToString() == carIdToDelete);

			Assert.Null(deletedCar);
		}

		[Test]
		public async Task DeleteByIdAsync_ShouldNotDeleteNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.DeleteByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task SoftDeleteCarByIdAsync_ShouldSoftDeleteCarCorrectly()
		{
			string carIdToDelete = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			await carService.SoftDeleteCarByIdAsync(carIdToDelete);

			var deletedCar = await dbContext
				.Cars
				.FirstOrDefaultAsync(c => c.Id.ToString() == carIdToDelete);

			Assert.NotNull(deletedCar);
			Assert.IsFalse(deletedCar.IsActive);
		}

		[Test]
		public async Task SoftDeleteCarByIdAsync_ShouldNotDeleteNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.SoftDeleteCarByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task IsRentedByIdAsync_ShouldReturnTrueForRentedCar()
		{
			string rentedCarId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			var rentedCar = await this.dbContext
				.Cars
				.FirstOrDefaultAsync(c => c.RenterId.ToString() == rentedCarId);

			var result = await carService.IsRentedByIdAsync(rentedCarId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsRentedByIdAsync_ShouldReturnFalseForNonRentedCar()
		{
			string nonRentedCarId = "d55c5de2-384c-4ffa-b830-8db7a8c17391";

			var notRentedCar = await this.dbContext
				.Cars
				.FirstOrDefaultAsync(c => c.RenterId.ToString() == nonRentedCarId);

			var result = await carService.IsRentedByIdAsync(nonRentedCarId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task IsRentedByIdAsync_ShouldThrowExceptionForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.IsRentedByIdAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task RentCarAsync_ShouldRentCarAndCreateRental()
		{
			string nonRentedCarId = "d55c5de2-384c-4ffa-b830-8db7a8c17391";
			string userId = "b792974e-1529-4167-8610-5c0fc4d94659";

			var notRentedCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.Id.ToString() == nonRentedCarId);
			
			notRentedCar.RenterId = Guid.Parse(userId);

			var rentalForm = new RentalFormView
			{
				CarId = nonRentedCarId,
				Days = 5,
				Deposit = 100,
				PhoneNumber = "1234567890"
			};

			await carService.RentCarAsync(rentalForm, userId);

			var rentedCar = await dbContext
				.Cars
				.FirstAsync(c => c.Id == notRentedCar.Id);

			var rental = await dbContext
				.Rentals
				.FirstAsync(r => r.CarId == notRentedCar.Id);

			var user = await this.dbContext
				.Users
				.FirstAsync(u => u.Id.ToString() == userId);	

			var userRentals = await dbContext
				.UsersRentals
				.FirstAsync(ur => ur.CustomerId == user.Id);

			var contact = await dbContext
				.Contacts
				.FirstAsync(c => c.CustomerId == user.Id);

			Assert.AreEqual(notRentedCar.Id, rental.CarId);
			Assert.AreEqual(notRentedCar.PricePerDay * rentalForm.Days, rental.Price);
			Assert.AreEqual(user.Id, userRentals.CustomerId);
			Assert.AreEqual(rental.Id, userRentals.RentalId);
			Assert.AreEqual(user.Email, contact.Email);
			Assert.AreEqual(rentalForm.PhoneNumber, contact.PhoneNumber);
		}

		[Test]
		public async Task RentCarAsync_ShouldUpdateUserPhoneNumberIfNotSet()
		{
			string nonRentedCarId = "d55c5de2-384c-4ffa-b830-8db7a8c17391";

			var rentalForm = new RentalFormView
			{
				CarId = nonRentedCarId,
				Days = 5,
				Deposit = 100,
				PhoneNumber = "1234567890"
			};

			string userId = "b792974e-1529-4167-8610-5c0fc4d94659";

			var user = await this.dbContext
				.Users
				.FirstAsync(u => u.Id.ToString() == userId);

			await carService.RentCarAsync(rentalForm, userId);

			var updatedUser = await dbContext
				.Users
				.FirstAsync(u => u.Id == user.Id);

			Assert.AreEqual(rentalForm.PhoneNumber, updatedUser.PhoneNumber);
		}

		[Test]
		public async Task RentCarAsync_ShouldThrowExceptionForNonExistingCar()
		{
			var rentalForm = new RentalFormView
			{
				CarId = "invalid",
				Days = 5,
				Deposit = 100,
				PhoneNumber = "1234567890"
			};

			string userId = "b792974e-1529-4167-8610-5c0fc4d94659";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.RentCarAsync(rentalForm, userId);
			});
		}

		[Test]
		public async Task RentCarAsync_ShouldThrowExceptionForNonExistingUser()
		{
			string nonRentedCarId = "d55c5de2-384c-4ffa-b830-8db7a8c17391";

			var rentalForm = new RentalFormView
			{
				CarId = nonRentedCarId,
				Days = 5,
				Deposit = 100,
				PhoneNumber = "1234567890"
			};

			string userId = "invalid";

			Assert.ThrowsAsync<FormatException>(async () =>
			{
				await carService.RentCarAsync(rentalForm, userId);
			});
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.RentCarAsync(rentalForm, Guid.NewGuid().ToString());
			});
		}

		[Test]
		public async Task IsRenterByUserWithIdAsync_ShouldReturnTrueForMatchingRenter()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";
			string userId = "4e191a73-e8d4-462d-9803-0400812d86cf";
			
			bool result = await carService.IsRenterByUserWithIdAsync(carId, userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsRenterByUserWithIdAsync_ShouldReturnFalseForNonMatchingRenter()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";
			string userId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";
			
			bool result = await carService.IsRenterByUserWithIdAsync(carId, userId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task IsRenterByUserWithIdAsync_ShouldThrowExceptionForNonExistingCar()
		{
			string carId = "invalid";
			string userId = "4e191a73-e8d4-462d-9803-0400812d86cf";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.IsRenterByUserWithIdAsync(carId, userId);
			});
		}

		[Test]
		public async Task LeaveCarAsync_ShouldRemoveRenterIdFromCar()
		{
			string carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";
			
			await carService.LeaveCarAsync(carId);

			var updatedCar = await dbContext.Cars.FindAsync(Guid.Parse(carId));

			Assert.Null(updatedCar.RenterId);
		}

		[Test]
		public async Task LeaveCarAsync_ShouldThrowExceptionForNonExistingCar()
		{
			string nonExistingCarId = "invalid";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.LeaveCarAsync(nonExistingCarId);
			});
		}

		[Test]
		public async Task AllDeletedAsync_ShouldReturnAllDeletedCars()
		{
			var result = await carService.AllDeletedAsync();

			int expectedDelCount = await this.dbContext
				.Cars
				.Where(c => !c.IsActive)
				.CountAsync();

			int actualDelcCount = result.Count();

			Assert.That(result, Is.Not.Null);
			Assert.That(expectedDelCount == actualDelcCount);
		}

		[Test]
		public async Task AllDeletedAsync_ShouldReturnEmptyListWhenNoDeletedCars()
		{
			var cars = await this.dbContext
				.Cars
				.Where(c => !c.IsActive)
				.ToArrayAsync();

			foreach (var car in cars)
			{
				car.IsActive = true;
			}

			await this.dbContext.SaveChangesAsync();

			var result = await carService.AllDeletedAsync();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public async Task AddDeletedCarByIdAsync_ShouldRestoreDeletedCar()
		{
			string carId = "7aed2a88-e55e-42a8-bef8-b421cdae4e2a";

			await carService.AddDeletedCarByIdAsync(carId);

			var restoredCar = await this.dbContext
				.Cars
				.FirstAsync(c => c.Id.ToString() == carId);

			Assert.That(restoredCar, Is.Not.Null);
			Assert.That(restoredCar.IsActive, Is.True);
		}

		[Test]
		public async Task AddDeletedCarByIdAsync_ShouldShouldThrowExceptionForActiveCar()
		{
			var carId = "179062a5-98aa-43cf-95ec-8f3fa3b99bb8";

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await carService.AddDeletedCarByIdAsync(carId);
			});
		}

	}
}