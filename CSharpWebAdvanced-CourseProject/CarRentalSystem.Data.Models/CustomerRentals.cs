namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CustomerRentals
    {
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(Rental))]
        public Guid RentalId { get; set; }
        public virtual Rental Rental { get; set; } = null!;
    }
}
