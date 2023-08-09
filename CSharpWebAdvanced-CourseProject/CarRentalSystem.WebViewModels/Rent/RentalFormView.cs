namespace CarRentalSystem.Web.ViewModels.Rent
{
	public class RentalFormView
	{
		public string? CarId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int? Deposit { get; set; }
        public int? Days { get; set; }
        public string Address { get; set; } = null!;
	}
}
