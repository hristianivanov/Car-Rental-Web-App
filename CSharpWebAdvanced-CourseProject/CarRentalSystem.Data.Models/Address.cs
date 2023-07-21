namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Address;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
            this.Customers = new HashSet<Customer>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Town { get; set; } = null!;

        [Required, MaxLength(StreetMaxLength)]
        public string Street { get; set; } = null!;

        [Required, MaxLength(ZipMaxLength)]
        public string ZIP { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}