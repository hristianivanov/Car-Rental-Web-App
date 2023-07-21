namespace CarRentalSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidationConstants.Customer;

	public class Customer : IdentityUser<Guid>
    {
		public Customer()
		{
			this.Contacts = new HashSet<Contact>();
			this.CustomerRentals = new HashSet<CustomerRentals>();
		}

		[Required, MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required, MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[ForeignKey(nameof(Address))]
		public Guid AddressId { get; set; }
		public virtual Address Address { get; set; } = null!;

		public virtual ICollection<Contact> Contacts { get; set; }
		public virtual ICollection<CustomerRentals> CustomerRentals { get; set; }
	}
}
