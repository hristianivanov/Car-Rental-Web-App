namespace CarRentalSystem.Web.Areas.Service.Data.Model
{
	using System.ComponentModel.DataAnnotations;

	public class Service
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(100)]
        public string Title { get; set; } = null!;

		[Required]
		[MaxLength(2048)]
        public string ImageUrl { get; set; } = null!;

        [Required] 
        [MaxLength(int.MaxValue)] 
        public string Text { get; set; } = null!;
	}
}
