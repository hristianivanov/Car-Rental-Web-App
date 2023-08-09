namespace CarRentalSystem.Web.Areas.Service.Data.Model
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Service;

	public class Service
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required] 
        [MaxLength(int.MaxValue)] 
        public string Text { get; set; } = null!;
	}
}
