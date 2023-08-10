using CarRentalSystem.Web.ViewModels.Car;

namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Blog;
	public interface IBlogService
	{
		Task<IEnumerable<BlogViewModel>> AllAsync();
		Task<bool> ExistByIdAsync(string blogId);
		Task<BlogDetailsViewModel> GetForDetailsByIdAsync(string blogId);
		Task<string> CreateAndReturnIdAsync(BlogFormModel formModel, string userId);
	}
}
