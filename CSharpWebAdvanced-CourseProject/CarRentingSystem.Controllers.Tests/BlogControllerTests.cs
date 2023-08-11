using System.Security.Claims;
using CarRentalSystem.Services.Data.Interfaces;
using CarRentalSystem.Web.Controllers;
using CarRentalSystem.Web.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarRentingSystem.Controllers.Tests
{
	public class BlogControllerTests
	{
		private Mock<IBlogService> mockBlogService;
		private BlogController blogController;

		[SetUp]
		public void Setup()
		{
			mockBlogService = new Mock<IBlogService>();
			blogController = new BlogController(mockBlogService.Object);
		}

		[Test]
		public async Task All_ReturnsCorrectViewAndModel()
		{
			var allBlogs = new List<BlogViewModel>
			{
				new BlogViewModel { Id = "1", Title = "Blog 1" },
				new BlogViewModel { Id = "2", Title = "Blog 2" }
			};

			mockBlogService.Setup(s => s.AllAsync())
				.ReturnsAsync(allBlogs);

			var result = await blogController.All();

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);
			var model = viewResult.Model as AllBlogViewModel;
			Assert.NotNull(model);
			Assert.AreEqual(allBlogs, model.Blogs);
			Assert.AreEqual("All", viewResult.ViewName);
		}

		[Test]
		public async Task Detail_WithValidId_ReturnsCorrectViewAndModel()
		{
			var blogId = Guid.NewGuid().ToString();
			var blogDetails = new BlogDetailsViewModel
			{
				Id = blogId,
				Title = "Test Blog",
				Description = "Test Description"
			};

			mockBlogService.Setup(s => s.ExistByIdAsync(blogId))
				.ReturnsAsync(true);
			mockBlogService.Setup(s => s.GetForDetailsByIdAsync(blogId))
				.ReturnsAsync(blogDetails);

			var result = await blogController.Detail(blogId);

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);
			var model = viewResult.Model as BlogDetailsViewModel;
			Assert.NotNull(model);
			Assert.AreEqual(blogDetails, model);
			Assert.AreEqual("Detail", viewResult.ViewName);
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
