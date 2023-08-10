using CarRentalSystem.Data.Models;

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
				.Select(b => new BlogViewModel()
				{
					Id = b.Id.ToString(),
					Title = b.Title,
					Description = b.Description,
					CreatedOn = b.CreatedOn,
					ImageUrl = b.ImageUrl,
				})
				.ToArrayAsync();

			return allBlogs;
		}

		public async Task<bool> ExistByIdAsync(string blogId)
		{
			bool result = await this.dbContext
				.Blogs
				.Where(b => b.IsActive)
				.AnyAsync(b => b.Id.ToString() == blogId);

			return result;
		}

		public async Task<BlogDetailsViewModel> GetForDetailsByIdAsync(string blogId)
		{
			Blog blog = await this.dbContext
				.Blogs
				.Include(b => b.Creater)
				.Where(b => b.IsActive)
				.FirstAsync(b => b.Id.ToString() == blogId);

			return new BlogDetailsViewModel
			{
				Id = blog.Id.ToString(),
				Title = blog.Title,
				Description = blog.Description,
				CreatedOn = blog.CreatedOn,
				ImageUrl = blog.ImageUrl,
				CreaterFullName = blog.Creater!.FirstName + ' ' + blog.Creater.LastName,
			};
		}
	}
}
