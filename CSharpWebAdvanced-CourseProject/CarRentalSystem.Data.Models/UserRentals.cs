namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserRentals
    {
        [ForeignKey(nameof(ApplicationUser))]
        public Guid CustomerId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Rental))]
        public Guid RentalId { get; set; }
        public virtual Rental Rental { get; set; } = null!;
    }
}
