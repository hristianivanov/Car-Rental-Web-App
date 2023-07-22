namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rental
    {
        public Rental()
        {
            this.Id = Guid.NewGuid();
            this.UserRentals = new HashSet<UserRentals>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!;

        public virtual ICollection<UserRentals> UserRentals { get; set; }
    }
}
