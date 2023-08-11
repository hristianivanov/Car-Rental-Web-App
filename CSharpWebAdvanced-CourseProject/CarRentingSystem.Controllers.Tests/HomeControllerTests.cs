namespace CarRentingSystem.Controllers.Tests
{
	using System.Security.Claims;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Http;

	using CarRentalSystem.Web.Controllers;
	using CarRentalSystem.Web.ViewModels.Home;

	[TestFixture]
	public class HomeControllerTests
	{
		private HomeController homeController;

		[OneTimeSetUp]
		public void SetUp()
			=>this.homeController = new HomeController(CarServiceMock.Instance);

		[TestCase(404)]
		[TestCase(401)]
		public void Error_ShouldReturnCorrectView(int statusCode)
		{
			var result = this.homeController.Error(statusCode);

			Assert.IsNotNull(result);

			var viewResult = result as ViewResult;
			Assert.IsNotNull(viewResult);
			Assert.AreEqual($"Error{statusCode}", viewResult.ViewName);
		}

		[Test]
		public async Task Error_ReturnsDefaultView_WhenStatusCodeIsNot404Or401()
		{
			var result = this.homeController.Error(500);

			var viewResult = result as ViewResult;

			Assert.NotNull(viewResult);
			Assert.IsNull(viewResult.ViewName);
		}

		[Test]
		public async Task Index_WhenUserIsAdmin_ShouldRedirectToAdminIndex()
		{
			var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "1"),
				new Claim(ClaimTypes.Role, "Master Administrator")
			}));

			homeController.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = adminUser }
			};

			var result = await homeController.Index();

			var redirectToActionResult = result as RedirectToActionResult;

			Assert.NotNull(redirectToActionResult);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
			Assert.AreEqual("Home", redirectToActionResult.ControllerName);
			Assert.AreEqual("Admin", redirectToActionResult.RouteValues["Area"]);
		}

		[Test]
		public async Task Index_WhenUserIsNotAdmin_ShouldReturnCorrectViewAndModel()
		{
			var expectedViewModel = new List<IndexViewModel>();

			var nonAdminUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "1")
			}));

			homeController.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = nonAdminUser }
			};

			var result = await homeController.Index();

			var viewResult = result as ViewResult;
			
			Assert.NotNull(viewResult);
			Assert.AreEqual(expectedViewModel, viewResult.Model);
		}

		[Test]
		public void About_ReturnsViewResult()
		{
			var result = homeController.About();

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);
		}

		[Test]
		public void Contact_ReturnsViewResult()
		{
			var result = homeController.Contact();

			var viewResult = result as ViewResult;
			Assert.NotNull(viewResult);
		}
	}
}
