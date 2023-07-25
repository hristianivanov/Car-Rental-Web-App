namespace CarRentalSystem.Web.ViewModels.Car
{
	using System.ComponentModel.DataAnnotations;

	using Data.Models.Enums;
	using static Common.EntityValidationConstants.Car;
	using static Common.EntityValidationConstants.Make;

	public class CarFormModel
	{
		public CarFormModel()
		{
			this.Transmissions = Enum.GetValues(typeof(Transmission)).Cast<Transmission>().ToHashSet();
			this.BodyTypes = Enum.GetValues(typeof(BodyType)).Cast<BodyType>().ToHashSet();
			this.EngineTypes = Enum.GetValues(typeof(EngineType)).Cast<EngineType>().ToHashSet();
		}

		[Required]
		[StringLength(MakeMaxLength, MinimumLength = MakeMinLength)]
		public string Make { get; set; } = null!;
		public int MakeId { get; set; }
		[Required]
		[StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
		public string Model { get; set; } = null!;

		[Range(typeof(decimal), PricePerDayMinValue, PricePerDayMaxValue)]
		[Display(Name = "Daily Price")]
		public decimal PricePerDay { get; set; }

		[Range(MileageMinValue, MileageMaxValue)]
		public uint Mileage { get; set; }

		[Range(0, double.MaxValue)]
		public double Acceleration { get; set; }

		[Range(0, ushort.MaxValue)]
		public ushort HorsePower { get; set; }

		[Range(0, ushort.MaxValue)]
		public ushort TopSpeed { get; set; }

		[Range(0, ushort.MaxValue)]
		public ushort Year { get; set; }

		[Range(0, double.MaxValue)]
		public double Consumption { get; set; }

		[Range(0, ushort.MaxValue)]
		public ushort Range { get; set; }

		[Range(SafetyMinValue, SafetyMaxValue)]
		public byte Safety { get; set; }

		[Range(PassengerSeatsMinValue, PassengerSeatsMaxValue)]
		public byte PassengerSeats { get; set; }
		[Required]
		[StringLength(ImageUrlMaxLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; }

		public EngineType SelectedEngineType { get; set; }
		public Transmission SelectedTransmission { get; set; }
		public BodyType SelectedBodyType { get; set; }

		public IEnumerable<EngineType> EngineTypes { get; set; }
		public IEnumerable<Transmission> Transmissions { get; set; }
		public IEnumerable<BodyType> BodyTypes { get; set; }
	}
}
