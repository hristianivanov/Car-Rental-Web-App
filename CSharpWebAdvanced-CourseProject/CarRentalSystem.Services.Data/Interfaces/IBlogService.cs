namespace CarRentalSystem.Services.Data.Interfaces
{
	using Web.ViewModels.Blog;
	public interface IBlogService
	{
		Task<IEnumerable<BlogViewModel>> AllAsync();
		Task<bool> ExistByIdAsync(string blogId);
		Task<BlogDetailsViewModel> GetForDetailsByIdAsync(string blogId);
		Task<string> CreateAndReturnIdAsync(BlogFormModel formModel, string userId);
		Task<BlogFormModel> GetBlogForEditByIdAsync(string blogId);
		Task EditBlogByIdAndFormModelAsync(string id, BlogFormModel blogModel);
		Task DeleteByIdAsync(string id);
	}
}
