namespace CarRentalSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class ImageData
	{
        public ImageData()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string OriginalFileName { get; set; }
        public string OriginalType { get; set; }

        public byte[] OriginalContent { get; set; }
        public byte[] ThumbnailContent { get; set; }
        public byte[] FullscreenContent { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
