namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserRentals
    {
        [ForeignKey(nameof(User))]
        public Guid CustomerId { get; set; }
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(Rental))]
        public Guid RentalId { get; set; }
        public virtual Rental Rental { get; set; } = null!;
    }
}
