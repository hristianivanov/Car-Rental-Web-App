namespace CarRentalSystem.Web.ViewModels.Rent
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Contact;
	public class RentalFormView
	{
		public string? CarId { get; set; }

		[Required]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength,
			ErrorMessage = "Invalid Phone Number")]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[Range(1, int.MaxValue, 
			ErrorMessage = "Deposit must be greater than 0")]
		public decimal? Deposit { get; set; }

		[Required]
		[Range(1, int.MaxValue,
			ErrorMessage = "Days must be greater than 0")]
		public int? Days { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; } = null!;
	}
}
