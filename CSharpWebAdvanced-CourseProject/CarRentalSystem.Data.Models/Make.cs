namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Make;

    public class Make
    {
        public Make()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(NewInnovationMaxLength)]
        public string? NewInnovation { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}