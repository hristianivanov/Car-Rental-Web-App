namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static CarRentalSystem.Common.EntityValidationConstants.Color;

    public class Color
    {
        public Color()
        {
            this.CarColors = new HashSet<CarColors>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        // Maybe it's temporarily until I decide how to get the photos
        [Required, MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        public virtual ICollection<CarColors> CarColors { get; set; }
    }
}