namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class BaseAdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
