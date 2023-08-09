namespace CarRentalSystem.Web.Areas.Service.ViewModels.Service
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Service;

	public class ServiceFormModel
	{
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;
		[Required]
		[StringLength(ImageUrlMaxLength)]
		public string ImageUrl { get; set; } = null!;
		[Required]
		[StringLength(int.MaxValue,MinimumLength = TextMinLength)]
        public string Text { get; set; } = null!;
	}
}
