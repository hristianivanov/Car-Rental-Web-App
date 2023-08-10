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
				.Where(b => b.IsActive)
				.Select(b => new BlogViewModel()
				{
					Id = b.Id.ToString(),
					Title = b.Title,
					Description = b.Description,
					CreatedOn = b.CreatedOn,
					ImageUrl = b.ImageUrl,
				})
				.OrderByDescending(b => b.CreatedOn)
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
				.Where(b => b.IsActive)
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

		public async Task<string> CreateAndReturnIdAsync(BlogFormModel formModel, string userId)
		{
			Blog blog = new Blog()
			{
				Title = formModel.Title,
				Description = formModel.Description,
				ImageUrl = formModel.ImageUrl,
				CreaterId = Guid.Parse(userId)
			};

			await this.dbContext.Blogs.AddAsync(blog);
			await this.dbContext.SaveChangesAsync();

			return blog.Id.ToString();
		}

		public async Task<BlogFormModel> GetBlogForEditByIdAsync(string blogId)
		{
			Blog blog = await this.dbContext
				.Blogs
				.Where(b => b.IsActive)
				.FirstAsync(b => b.Id.ToString() == blogId);

			return new BlogFormModel()
			{
				Title = blog.Title,
				Description = blog.Description,
				ImageUrl = blog.ImageUrl,
			};
		}

		public async Task EditBlogByIdAndFormModelAsync(string id, BlogFormModel blogModel)
		{
			Blog blog = await this.dbContext
				.Blogs
				.Where(c => c.IsActive)
				.FirstAsync(c => c.Id.ToString() == id);

			blog.Title = blogModel.Title;
			blog.ImageUrl = blogModel.ImageUrl;
			blog.Description = blogModel.Description;

			await this.dbContext.SaveChangesAsync();
		}

		public async Task DeleteByIdAsync(string id)
		{
			Blog blog = await this.dbContext
				.Blogs
				.Where(b => b.IsActive)
				.FirstAsync(c => c.Id.ToString() == id);

			blog.IsActive = false;

			await this.dbContext.SaveChangesAsync();
		}

		public async Task<bool> IsCreaterWithIdAsync(string id, string userId)
		{
			Blog blog = await this.dbContext
				.Blogs
				.FirstAsync(c => c.Id.ToString() == id);

			return blog.IsActive
			       && blog.CreaterId.ToString() == userId;
		}
	}
}
