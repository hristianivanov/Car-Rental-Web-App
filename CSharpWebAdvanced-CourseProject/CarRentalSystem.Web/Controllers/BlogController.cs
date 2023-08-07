namespace CarRentalSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class BlogController : Controller
	{
		public IActionResult All()
		{
			return View();
		}
	}
}
