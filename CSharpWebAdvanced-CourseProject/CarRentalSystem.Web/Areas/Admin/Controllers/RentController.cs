using System.Collections;

namespace CarRentalSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Rent;
	using Microsoft.Extensions.Caching.Memory;
	using static Common.GeneralApplicationConstants;

	public class RentController : BaseAdminController
	{
		private readonly IRentService rentService;
		private readonly IMemoryCache memoryCache;

		public RentController(IRentService rentService, IMemoryCache memoryCache)
		{
			this.rentService = rentService;
			this.memoryCache = memoryCache;
		}

		[Route("Rent/All")]
		[ResponseCache(Duration = 120)]
		public async Task<IActionResult> All()
		{
			IEnumerable<RentViewModel> allRents =
				this.memoryCache.Get<IEnumerable<RentViewModel>>(RentsCacheKey);

			if (allRents == null)
			{
				allRents = await this.rentService.AllAsync();

				var cacheOpt = new MemoryCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromMinutes(RentsCacheDurationMinutes));

				this.memoryCache.Set(RentsCacheKey, allRents, cacheOpt);
			}

			return View(allRents);
		}
	}
}
