namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Blog;
	public interface IBlogService
	{
		Task<IEnumerable<BlogViewModel>> AllAsync();
	}
}
