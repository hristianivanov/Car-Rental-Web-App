namespace CarRentalSystem.Web.ViewModels.Blog
{
	public class BlogViewModel
	{
		public string Id { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
	}
}
