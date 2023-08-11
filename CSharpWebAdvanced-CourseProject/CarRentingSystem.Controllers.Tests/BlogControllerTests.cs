namespace CarRentingSystem.Controllers.Tests
{
	using System.Security.Claims;

	using Microsoft.AspNetCore.Mvc;

	using Services.Mocks;
	using CarRentalSystem.Web.Controllers;
	using CarRentalSystem.Web.ViewModels.Blog;

	public class BlogControllerTests
	{
		private BlogController blogController;

		[OneTimeSetUp]
		public void Setup()
			=> this.blogController = new BlogController(BlogServiceMock.Instance());

		[Test]
		public async Task All_ReturnsCorrectViewAndModel()
		{
			var allBlogs = new List<BlogViewModel>
			{
				new BlogViewModel
				{
					Id = Guid.NewGuid().ToString(),
					Title = "title",
					Description = "description",
					ImageUrl = "test.png",
					CreatedOn = DateTime.UtcNow,
				},
				new BlogViewModel
				{
					Id = Guid.NewGuid().ToString(),
					Title = "title",
					Description = "description",
					ImageUrl = "test.png",
					CreatedOn = DateTime.UtcNow,
				}
			};

			var blogService = BlogServiceMock.CreateInstance(allBlogs);
			var blogController = new BlogController(blogService);

			var result = await blogController.All();

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);

			var model = viewResult.Model as AllBlogViewModel;
			Assert.NotNull(model);

			Assert.IsTrue(allBlogs.Count() == model.Blogs.Count());
		}

		[Test]
		public async Task Detail_WhenBlogExists_ShouldReturnCorrectViewAndModel()
		{
			var blogId = Guid.NewGuid().ToString();

			var expectedViewModel = new BlogDetailsViewModel
			{
				Id = blogId,
				Title = "title",
				Description = "description",
				CreatedOn = DateTime.UtcNow,
				CreaterFullName = "Pesho Petrov",
				ImageUrl = "test.png",
			};

			var blogServiceMock = BlogServiceMock.Instance(expectedViewModel);
			var blogController = new BlogController(blogServiceMock);

			var result = await blogController.Detail(blogId);

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);

			var model = viewResult.Model as BlogDetailsViewModel;
			Assert.NotNull(model);

			Assert.AreEqual(expectedViewModel.Id, model.Id);
			Assert.AreEqual(expectedViewModel.Title, model.Title);
			Assert.AreEqual(expectedViewModel.Description, model.Description);
			Assert.AreEqual(expectedViewModel.CreatedOn, model.CreatedOn);
			Assert.AreEqual(expectedViewModel.CreaterFullName, model.CreaterFullName);
			Assert.AreEqual(expectedViewModel.ImageUrl, model.ImageUrl);
		}


		private static ClaimsPrincipal CreateClaimsPrincipal(string userId, bool isAdmin)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId)
			};

			if (isAdmin)
			{
				claims.Add(new Claim(ClaimTypes.Role, "Admin"));
			}

			var identity = new ClaimsIdentity(claims, "Test");
			return new ClaimsPrincipal(identity);
		}
	}
}
