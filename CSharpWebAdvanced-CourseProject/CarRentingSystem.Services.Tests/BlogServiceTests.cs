using CarRentalSystem.Data.Models;
using CarRentalSystem.Web.ViewModels.Blog;

namespace CarRentingSystem.Services.Tests
{
	using CarRentalSystem.Data;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Services.Data;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	[TestFixture]
	public class BlogServiceTests
	{
		private DbContextOptions<CarRentingDbContext> dbOptions;
		private CarRentingDbContext dbContext;

		private IBlogService blogService;
		public string existingActiveBlogId;
		public string inactiveBlogId;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
				.UseInMemoryDatabase("CarRentingInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new CarRentingDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			existingActiveBlogId = "3a476437-ec4a-4950-a66b-5aa785234186";
			inactiveBlogId = "951e54e1-2d76-4f6b-b48f-3c4c186c1d05";
			this.blogService = new BlogService(this.dbContext);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task AllAsync_ShouldReturnActiveBlogs()
		{
			var activeBlogs = await this.dbContext
				.Blogs
				.Where(b => b.IsActive)
				.ToListAsync();

			var result = await blogService.AllAsync();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Has.Exactly(activeBlogs.Count)
				.Matches<BlogViewModel>(blog => activeBlogs.Any(b => b.Id.ToString() == blog.Id)));
		}

		[Test]
		public async Task AllAsync_ShouldNotReturnInactiveBlogs()
		{
			var inactiveBlogs = await this.dbContext
				.Blogs
				.Where(b => !b.IsActive)
				.ToListAsync();

			var result = await blogService.AllAsync();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Has.None
				.Matches<BlogViewModel>(blog => inactiveBlogs.Any(b => b.Id.ToString() == blog.Id)));
		}

		[Test]
		public async Task AllAsync_ShouldReturnBlogsInDescendingOrderByCreatedOn()
		{
			var blogs = await this.dbContext
				.Blogs
				.Where(b => b.IsActive)
				.OrderByDescending(b => b.CreatedOn)
				.ToListAsync();

			var result = await blogService.AllAsync();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Ordered.By(nameof(BlogViewModel.CreatedOn)).Descending);
		}

		[Test]
		public async Task ExistByIdAsync_ShouldReturnTrueForExistingActiveBlog()
		{
			var result = await blogService.ExistByIdAsync(existingActiveBlogId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task ExistByIdAsync_ShouldReturnFalseForNonExistingBlog()
		{
			var nonExistingBlogId = Guid.NewGuid().ToString();

			var result = await blogService.ExistByIdAsync(nonExistingBlogId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task ExistByIdAsync_ShouldReturnFalseForInactiveBlog()
		{
			var result = await blogService.ExistByIdAsync(inactiveBlogId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetForDetailsByIdAsync_ShouldReturnCorrectDetailsForExistingActiveBlog()
		{
			Blog existingActiveBlog = await this.dbContext
				.Blogs
				.FirstAsync(b => b.Id.ToString() == existingActiveBlogId);

			var result = await blogService.GetForDetailsByIdAsync(existingActiveBlogId);

			Assert.NotNull(result);
			Assert.AreEqual(existingActiveBlog.Id.ToString(), result.Id);
			Assert.AreEqual(existingActiveBlog.Title, result.Title);
			Assert.AreEqual(existingActiveBlog.Description, result.Description);
			Assert.AreEqual(existingActiveBlog.CreatedOn, result.CreatedOn);
			Assert.AreEqual(existingActiveBlog.ImageUrl, result.ImageUrl);
			Assert.AreEqual($"{existingActiveBlog.Creater.FirstName} {existingActiveBlog.Creater.LastName}", result.CreaterFullName);
		}

		[Test]
		public async Task GetForDetailsByIdAsync_ShouldThrowExceptionNonExistingBlog()
		{
			var nonExistingBlogId = Guid.NewGuid().ToString();

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				var result = await blogService.GetForDetailsByIdAsync(nonExistingBlogId);
			});
		}

		[Test]
		public async Task GetForDetailsByIdAsync_ShouldThrowExceptionForInactiveBlog()
		{
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				var result = await blogService.GetForDetailsByIdAsync(inactiveBlogId);
			});
		}

		[Test]
		public async Task CreateAndReturnIdAsync_ShouldAddBlogAndReturnNewId()
		{
			var formModel = new BlogFormModel
			{
				Title = "New Blog Title",
				Description = "New Blog Description",
				ImageUrl = "new-blog-image.png"
			};

			var userId = Guid.NewGuid().ToString();

			var newBlogId = await blogService.CreateAndReturnIdAsync(formModel, userId);

			var createdBlog = await dbContext.Blogs.FindAsync(Guid.Parse(newBlogId));
			Assert.NotNull(createdBlog);
			Assert.AreEqual(formModel.Title, createdBlog.Title);
			Assert.AreEqual(formModel.Description, createdBlog.Description);
			Assert.AreEqual(formModel.ImageUrl, createdBlog.ImageUrl);
			Assert.AreEqual(userId, createdBlog.CreaterId.ToString());
		}

		[Test]
		public async Task GetBlogForEditByIdAsync_ShouldReturnCorrectBlogFormModel()
		{
			Blog blog = await this.dbContext
				.Blogs
				.FirstAsync(b => b.Id.ToString() == existingActiveBlogId);

			var result = await blogService.GetBlogForEditByIdAsync(blog.Id.ToString());

			Assert.NotNull(result);
			Assert.AreEqual(blog.Title, result.Title);
			Assert.AreEqual(blog.Description, result.Description);
			Assert.AreEqual(blog.ImageUrl, result.ImageUrl);
		}


		[Test]
		public async Task EditBlogByIdAndFormModelAsync_ShouldEditBlogCorrectly()
		{
			Blog blog = await this.dbContext
				.Blogs
				.FirstAsync(b => b.Id.ToString() == existingActiveBlogId);

			var newBlogModel = new BlogFormModel
			{
				Title = "New Title",
				Description = "New Description",
				ImageUrl = "new-image.png"
			};

			await blogService.EditBlogByIdAndFormModelAsync(blog.Id.ToString(), newBlogModel);

			var editedBlog = this.dbContext
				.Blogs
				.FirstOrDefault(b => b.Id.ToString() == blog.Id.ToString());

			Assert.NotNull(editedBlog);
			Assert.AreEqual(newBlogModel.Title, editedBlog.Title);
			Assert.AreEqual(newBlogModel.Description, editedBlog.Description);
			Assert.AreEqual(newBlogModel.ImageUrl, editedBlog.ImageUrl);
		}

		[Test]
		public async Task DeleteByIdAsync_ShouldSoftDeleteBlogCorrectly()
		{
			Blog blog = await this.dbContext
				.Blogs
				.FirstAsync(b => b.Id.ToString() == existingActiveBlogId);

			await blogService.DeleteByIdAsync(blog.Id.ToString());

			var deletedBlog = this.dbContext
				.Blogs
				.FirstOrDefault(b => b.Id.ToString() == blog.Id.ToString());

			Assert.NotNull(deletedBlog);
			Assert.IsFalse(deletedBlog.IsActive);
		}

		[Test]
		public async Task IsCreaterWithIdAsync_ShouldReturnTrueForMatchingCreaterId()
		{
			Blog blog = await this.dbContext
				.Blogs
				.FirstAsync(b => b.Id.ToString() == existingActiveBlogId);
			
			var result = await blogService.IsCreaterWithIdAsync(blog.Id.ToString(), blog.Creater.Id.ToString());

			Assert.IsTrue(result);
		}

	}
}
