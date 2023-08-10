namespace CarRentalSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using CarRentalSystem.Data;
	using Interfaces;
	using Web.ViewModels.Blog;

	public class BlogService : IBlogService
	{
		private readonly CarRentingDbContext dbContext;

		public BlogService(CarRentingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<BlogViewModel>> AllAsync()
		{
			IEnumerable<BlogViewModel> allBlogs = await this.dbContext
				.Blogs
				.Select(s => new BlogViewModel()
				{
					Id = s.Id.ToString(),
					Title = s.Title,
					Description = s.Description,
					CreatedOn = s.CreatedOn,
					ImageUrl = s.ImageUrl,
				})
				.ToArrayAsync();

			return allBlogs;
		}
	}
}
