namespace CarRentalSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidationConstants.Customer;

	public class ApplicationUser : IdentityUser<Guid>
    {
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
			this.Contacts = new HashSet<Contact>();
			this.UserRentals = new HashSet<UserRentals>();
			this.Blogs = new HashSet<Blog>();
			this.SecurityStamp = Guid.NewGuid().ToString();
		}

		[Required, MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required, MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
		public virtual ICollection<UserRentals> UserRentals { get; set; }
	}
}
