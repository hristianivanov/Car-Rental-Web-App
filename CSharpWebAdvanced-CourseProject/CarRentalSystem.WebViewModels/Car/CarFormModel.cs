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
        [RegularExpression(@"^[a-zA-Z\s]+$",
			ErrorMessage = "The Make field should contain only letters.")]
        public string Make { get; set; } = null!;
        public int MakeId { get; set; }
        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [RegularExpression(@"^[a-zA-Z0-9\s-]+$",
            ErrorMessage = "The Model field should contain only letters, numbers, spaces, and dashes.")]
        public string Model { get; set; } = null!;

        [Range(typeof(decimal), PricePerDayMinValue, PricePerDayMaxValue)]
        [Display(Name = "Daily Price")]
        public decimal PricePerDay { get; set; }

        [Range(MileageMinValue, MileageMaxValue,
            ErrorMessage = "The field Mileage must be between 0 and 1 million.")]
        public uint Mileage { get; set; }

        [Range(0, double.MaxValue,
            ErrorMessage = "Acceleration must be a positive number.")]
        public double Acceleration { get; set; }

        [Range(0, ushort.MaxValue,
            ErrorMessage = "Horse power must be a positive number.")]
        public ushort HorsePower { get; set; }

        [Range(0, ushort.MaxValue,
            ErrorMessage = "Top speed must be a positive number.")]
        public ushort TopSpeed { get; set; }

        [Range(YearMinValue, YearMaxValue,
            ErrorMessage = "Year must be a positive number.")]
        public ushort Year { get; set; }

        [Range(0, double.MaxValue,
            ErrorMessage = "Consumption must be a positive number.")]
        public double Consumption { get; set; }

        [Range(0, ushort.MaxValue,
            ErrorMessage = "Range must be a positive number.")]
        public ushort Range { get; set; }

        [Range(SafetyMinValue, SafetyMaxValue,
            ErrorMessage = "Safety mark must be between 1 to 5.")]
        public byte Safety { get; set; }

        [Range(PassengerSeatsMinValue, PassengerSeatsMaxValue)]
        public byte PassengerSeats { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        //[RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|png)",
        //    ErrorMessage = "Please enter a valid image URL (jpg or png).")]
        public string ImageUrl { get; set; }

        public EngineType SelectedEngineType { get; set; }
        public Transmission SelectedTransmission { get; set; }
        public BodyType SelectedBodyType { get; set; }

        public IEnumerable<EngineType> EngineTypes { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
        public IEnumerable<BodyType> BodyTypes { get; set; }
    }
}
