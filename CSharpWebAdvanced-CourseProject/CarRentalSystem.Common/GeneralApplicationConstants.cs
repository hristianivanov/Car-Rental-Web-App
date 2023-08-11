namespace CarRentalSystem.Common
{
	public static class GeneralApplicationConstants
	{
		public const int ReleaseYear = 2021;

		public const int DefaultPage = 1;
		public const int EntitiesPerPage = 6;
		public const int LastCarsInCarocel = 6;

		public const string AdminAreaName = "Admin";
		public const string AdminRoleName = "Admin";
		public const string DevelopmentAdminEmail = "admin@gmail.com";

		public const string UsersCacheKey = "UsersCache";
		public const string RentsCacheKey = "RentsCache";
		
		public const int RentsCacheDurationMinutes = 10;

		public const string OnlineUsersCookieName = "IsOnline";
		public const int LastActivityBeforeOfflineMinutes = 10;

		public const string SiteAddress = "Samara 25 , 6180 Maglizh";
		public const string SiteEmail = "site_test@gmail.com";
		public const string SitePhoneNumber = "0898785391";
	}
}
