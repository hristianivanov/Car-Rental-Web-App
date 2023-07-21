namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    using static CarRentalSystem.Common.EntityValidationConstants.Car;

    public class Car
    {
	    public Car()
        {
            this.CarColors = new HashSet<CarColors>();
            this.Rentals = new HashSet<Rental>();
        }

		//TODO: think of sensitive data in entity models changed them in GUID
		[Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }
        public virtual Make Make { get; set; } = null!;

        [Required, MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        public BodyType BodyType { get; set; }
        public Transmission Transmission { get; set; }
        // in miles
        public uint? Mileage { get; set; }
        // cannot be negative number
		public double Acceleration { get; set; }
        public ushort HorsePower { get; set; }
        // in mph 
        // cannot be negative number
        public ushort TopSpeed { get; set; }
        // cannot be negative number
		public ushort Year { get; set; }
        // cannot be negative number
		public byte FuelAmount { get; set; }

        [MaxLength(ConsumptionMaxValue)]
        public double Consumption { get; set; }
		//distance a car can travel with residual fuel in the fuel tank
		// cannot be negative number
		public ushort Range { get; set; }
        //1 to 5
        // cannot be negative number
        [MaxLength(SafetyMaxValue)]
		public byte Safety { get; set; }

        [MaxLength(PassengerSeatsMaxValue)]
        public byte PassengerSeats { get; set; }

        //TODO: think of how you store car photos
        //public string[] ImageUrls { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<CarColors> CarColors { get; set; }
    }
}
