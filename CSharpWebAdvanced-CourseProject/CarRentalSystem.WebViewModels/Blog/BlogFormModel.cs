namespace CarRentalSystem.Web.ViewModels.Blog
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Blog;

	public class BlogFormModel
	{
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(int.MaxValue, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		[StringLength(ImageUrlMaxLength)]
		public string ImageUrl { get; set; } = null!;
	}
}