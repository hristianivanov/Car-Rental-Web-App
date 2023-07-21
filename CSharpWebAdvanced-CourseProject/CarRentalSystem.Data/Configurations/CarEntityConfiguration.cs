namespace CarRentalSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;
	using Models.Enums;

	public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasData(this.GenerateCars());
		}

		private ICollection<Car> GenerateCars()
		{
			var cars = new HashSet<Car>();

			cars.Add(new Car()
			{
				Id = 1,
				MakeId = 3,
				Model = "RS e-tron GT",
				BodyType = BodyType.Coupe,
				Transmission = Transmission.Auto,
				Acceleration = 2.9,
				Mileage = 5_000,
				HorsePower = 637,
				TopSpeed = 155,
				Year = 2021,
				Consumption = 20.2,
				Range = 298,
				Safety = 5,
				PassengerSeats = 5
			});
			cars.Add(new Car()
			{
				Id = 2,
				MakeId = 3,
				Model = "A5 SB basic",
				BodyType = BodyType.Hatchback,
				Transmission = Transmission.Auto,
				Acceleration = 6.2,
				Mileage = 450_000,
				HorsePower = 261,
				TopSpeed = 126,
				Year = 2013,
				Consumption = 6.2,
				Range = 520,
				Safety = 4,
				PassengerSeats = 5
			});
			cars.Add(new Car()
			{
				Id = 3,
				MakeId = 4,
				Model = "X6 40d",
				BodyType = BodyType.SUV,
				Transmission = Transmission.Auto,
				Acceleration = 5.5,
				Mileage = 53_000,
				HorsePower = 340,
				TopSpeed = 147,
				Year = 2012,
				Consumption = 7.1,
				Range = 704,
				Safety = 4,
				PassengerSeats = 5
			});

			return cars;
		}
	}
}
