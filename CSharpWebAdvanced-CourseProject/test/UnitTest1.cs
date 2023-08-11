using CarRentalSystem.Services.Data.Interfaces;
using CarRentalSystem.Web.Controllers;
using CarRentalSystem.Web.ViewModels.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace test
{
	using System.Security.Claims;

	public class BlogControllerTests
	{
		private readonly Mock<IBlogService> mockBlogService;
		private readonly BlogController blogController;

		public BlogControllerTests()
		{
			this.mockBlogService = new Mock<IBlogService>();
			this.blogController = new BlogController(this.mockBlogService.Object);
		}

		[Fact]
		public async Task All_ReturnsCorrectViewAndModel()
		{
			// Arrange
			var allBlogs = new List<BlogViewModel>
		{
			new BlogViewModel { Id = "1", Title = "Blog 1" },
			new BlogViewModel { Id = "2", Title = "Blog 2" }
		};

			this.mockBlogService.Setup(s => s.AllAsync())
				.ReturnsAsync(allBlogs);

			// Act
			var result = await this.blogController.All();

			// Assert
			var viewResult = Assert.IsType<ViewResult>(result);
			var model = Assert.IsType<AllBlogViewModel>(viewResult.Model);
			Assert.Equal(allBlogs, model.Blogs);
			Assert.Equal("All", viewResult.ViewName);
		}

		[Fact]
		public async Task Detail_WithExistingBlog_ReturnsCorrectViewAndModel()
		{
			// Arrange
			var blogId = "1";
			var blogDetailsViewModel = new BlogDetailsViewModel
			{
				Id = blogId,
				Title = "Blog Title"
			};

			this.mockBlogService.Setup(s => s.ExistByIdAsync(blogId))
				.ReturnsAsync(true);
			this.mockBlogService.Setup(s => s.GetForDetailsByIdAsync(blogId))
				.ReturnsAsync(blogDetailsViewModel);

			// Act
			var result = await this.blogController.Detail(blogId);

			// Assert
			var viewResult = Assert.IsType<ViewResult>(result);
			var model = Assert.IsType<BlogDetailsViewModel>(viewResult.Model);
			Assert.Equal(blogDetailsViewModel, model);
			Assert.Equal("Detail", viewResult.ViewName);
		}

		[Fact]
		public async Task Add_WithValidModelState_ReturnsRedirectToActionResult()
		{
			// Arrange
			var formModel = new BlogFormModel { Title = "New Blog", Description = "Description" };
			var userId = "user123";

			this.blogController.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = CreateUserWithId(userId) }
			};

			this.mockBlogService.Setup(s => s.CreateAndReturnIdAsync(formModel, userId))
				.ReturnsAsync("new-blog-id");

			// Act
			var result = await this.blogController.Add(formModel);

			// Assert
			var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
			Assert.Equal("Detail", redirectToActionResult.ActionName);
			Assert.Equal("Blog", redirectToActionResult.ControllerName);
			Assert.Equal("new-blog-id", redirectToActionResult.RouteValues["id"]);
		}

		// Add more tests for other methods as needed

		private ClaimsPrincipal CreateUserWithId(string userId)
		{
			var identity = new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) });
			return new ClaimsPrincipal(identity);
		}
	}

}