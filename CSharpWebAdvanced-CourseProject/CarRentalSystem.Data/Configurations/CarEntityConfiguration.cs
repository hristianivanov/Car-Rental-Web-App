namespace CarRentalSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;
	using Models.Enums;
	using static System.Net.WebRequestMethods;

	public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder
				.Property(c => c.IsActive)
				.HasDefaultValue(true);

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
				ImageUrl = "https://www.carpixel.net/w/fb81ff032f94a62ab3734238828ca57c/audi-rs-e-tron-gt-car-wallpaper-103179.jpg",
				EngineType = EngineType.Electric, 
				PricePerDay = 420,
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
				ImageUrl = "https://imagizer.imageshack.com/a/img29/5097/gu89.jpg",
				EngineType = EngineType.Diesel,
				PricePerDay = 329,
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
				ImageUrl = "https://avatars.mds.yandex.net/get-autoru-vos/5234682/06057d0f4b94a888f5c8112546a31a43/1200x900",
				EngineType = EngineType.Diesel,
				PricePerDay = 412,
				Range = 704,
				Safety = 4,
				PassengerSeats = 5
			});
			cars.Add(new Car()
			{
				Id = 4,
				MakeId = 6,
				Model = "F430",
				BodyType = BodyType.Sport,
				Transmission = Transmission.Auto,
				Acceleration = 3.6,
				Mileage = 230_532,
				HorsePower = 483,
				TopSpeed = 196,
				Year = 2004,
				Consumption = 18.3,
				ImageUrl = "https://photos.carspecs.us/d389399428d2ba5d065c5b6f59aaf3771a41ca4b-2000.jpg",
				EngineType = EngineType.Diesel,
				PricePerDay = 620,
				Range = 323,
				Safety = 3,
				PassengerSeats = 2
			});
			cars.Add(new Car()
			{
				Id = 5,
				MakeId = 2,
				Model = "Giulia",
				BodyType = BodyType.Sedan,
				Transmission = Transmission.Manual,
				Acceleration = 5.4,
				Mileage = 623_142,
				HorsePower = 280,
				TopSpeed = 191,
				Year = 2018,
				Consumption = 28.5,
				ImageUrl = "https://yandex-images.clstorage.net/e9YZ9F383/e3049dM4PtiR/48AJY79fj0JYkNVSm-meE7lJbsJRL_EQAcWW2JV-OOBHJ2BVk10QiQJdiHxO8fKyuG6pwiz5nm8PCEny6b7Z1NK0zce-6ioWORWV0qu5v8ZteH8H8WogtCQFEogQHpilMcGSV8QLx09Qqt-L3yTiZ70KPQcpHH25vkgrpF9seWMh0RtA-05t8g9z5_Cqisylaqsv5nI4ELLGtvL_QCnPA6CCMNV0ChQekVq9KB4HYBRvKVmkCxx-qMiI2odeP4uhIhMocsleX3EcQMfjS_j-plgLfQZBq5Mg9jcTn2DZDTDC40FUxYp0vNGoXFsM53B1DykZ1wqN7QlKeBl37VwJcFLiCSLr7c5R3vP0ULlKX4R5-Y9HMXhAspdUYI9yW4_hUsARxzQIJq7xCe-4v-SCVX9omqQI_r7I2iraxu_c6XBRkHjB-Uz_833jhODaqW_HSMitx4PbcSF0lFLd8NhM80Gg8MaGihVNAHnP-4xEwCZua5j2ec_8KsrI2qUtjJiBEFDI4qld3IO-slQiyvhuxZkKf8fxyuGRNuSQjxB7jBJiYfCW5OqljSFY7bmP5XDEvnnpJJrsDPsKeTnl3944U3HiaVCrf85SzABEcznbTuf6mH32gXly8BZmkX8wqH7BouHiZaWI9dzBqH_anRXgNp0622QbHExauspot9wMu-PCckjyqexdYu1QJgILKe9E2jh9FzLZQIC0dtKPY4ksIkCSQiVUOyVcYunsSx6mUYXvSRs1Kq8_Gis5WqZcTjhTQeIqAjkuHmI9QkYiashPVmk6PhZT-kFTBMXi3KGpnyGQg3L1VzrE_mJrjygs9jGmjdiYpriuTCr4edjW7o4a0OLQWmBbzi_R_IHWUfqp7hQ7yU6HgTox8Ce1gIyDe76Q00MSJPZalN7CGv5L7KQAlI4q2XaanoxoKnopl6yf-zMwkUhwq-5MU36iF9Cq6P2nmJtfRnH7EAL1t0Lfc",
				EngineType = EngineType.Diesel,
				PricePerDay = 205,
				Range = 464,
				Safety = 4,
				PassengerSeats = 5
			});
			cars.Add(new Car()
			{
				Id = 6,
				MakeId = 4,
				Model = "e60 M5",
				BodyType = BodyType.Sedan,
				Transmission = Transmission.Auto,
				Acceleration = 4.5,
				Mileage = 575_531,
				HorsePower = 500,
				TopSpeed = 190,
				Year = 2005,
				Consumption = 22.7,
				ImageUrl = "https://sun9-46.userapi.com/impg/jGF9KYUrkOJ81ExMSYNNE4L7fh4GD5Ryoic6zA/Iy6iwscdEg0.jpg?size=1920x1280&quality=95&sign=637909ae3d1112f8306502533c876ba3&c_uniq_tag=3K2cQHcDOmacj7mo5PNx7wX_XCN3EOQggqEfBc4h6iI&type=album",
				EngineType = EngineType.Diesel,
				PricePerDay = 130,
				Range = 293,
				Safety = 3,
				PassengerSeats = 5
			});

			return cars;
		}
	}
}
