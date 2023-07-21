namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CarColors
    {
        //TODO: pk
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!;

        [ForeignKey(nameof(Color))]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; } = null!;
    }
}