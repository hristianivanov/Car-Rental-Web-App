namespace CarRentingSystem.Services.Mocks
{
	using Moq;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Blog;

	public class BlogServiceMock
	{
		public static IBlogService Instance(BlogDetailsViewModel blogDetailsViewModel = null)
		{
			var blogServiceMock = new Mock<IBlogService>();

			blogServiceMock.Setup(s => s.ExistByIdAsync(It.IsAny<string>()))
				.ReturnsAsync(true);
			blogServiceMock.Setup(s => s.GetForDetailsByIdAsync(It.IsAny<string>()))
				.ReturnsAsync(blogDetailsViewModel);

			return blogServiceMock.Object;
		}
		public static IBlogService CreateInstance(IEnumerable<BlogViewModel> allBlogs)
		{
			var blogServiceMock = new Mock<IBlogService>();

			blogServiceMock.Setup(s => s.AllAsync())
				.ReturnsAsync(allBlogs);

			return blogServiceMock.Object;
		}
	}
}
