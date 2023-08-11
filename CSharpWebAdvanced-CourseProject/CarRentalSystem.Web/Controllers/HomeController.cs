namespace CarRentalSystem.Web.Controllers
{
	using System.Net;
	using System.Net.Mail;
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using Infrastructure.Extensions;
	using static Common.GeneralApplicationConstants;
	using static Common.NotificationMessagesConstants;

	public class HomeController : Controller
	{
		private readonly ICarService carService;

		public HomeController(ICarService carService)
		{
			this.carService = carService;

		}

		public async Task<IActionResult> Index()
		{
			if (this.User.IsAdmin())
			{
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			var viewModel = await this.carService.LastCarsAsync(LastCarsInCarocel);

			return View(viewModel);
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return this.View();
		}

		[HttpPost]
		public IActionResult Contact(string Name, string Email, string Subject, string Message)
		{
			try
			{
				this.SendMail(Name, Email, Message, Subject);

				this.TempData[SuccessMessage] = "The email was successfully sent!";
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = "Unexpected error occurred!";

				return RedirectToAction("Contact", "Home", new { Name, Email, Subject, Message });
			}
			this.TempData[SuccessMessage] = "Message sent!";

			return RedirectToAction("Contact", "Home");
		}

		public void SendMail(string name, string email, string message, string subject)
		{
			var body = $"Name: {name}" + $"{Environment.NewLine}" +
					   $"Message: {message}";

			var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
			{
				Credentials = new NetworkCredential("4afc6c39e638dd", "1eab87e41d5e8c"),
				EnableSsl = true
			};
			client.Send(email, SiteEmail, subject, body);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404 || statusCode == 400)
			{
				return this.View("Error404");
			}

			if (statusCode == 401)
			{
				return this.View("Error401");
			}
			return View();
		}
	}
}