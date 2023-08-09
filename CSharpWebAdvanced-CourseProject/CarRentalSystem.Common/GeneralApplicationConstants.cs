namespace CarRentalSystem.Common
{
	public static class GeneralApplicationConstants
	{
		public const int ReleaseYear = 2021;
		public const int LastCarsInCarocel = 6;
		public const int DefaultPage = 1;
		public const int EntitiesPerPage = 6;

		public const string AdminAreaName = "Admin";
		public const string AdminRoleName = "Master Administrator";
		public const string DevelopmentAdminEmail = "admin@gmail.com";

		public const string UsersCacheKey = "UsersCache";
		public const string RentsCacheKey = "RentsCache";
		
		public const int RentsCacheDurationMinutes = 10;

		public const string OnlineUsersCookieName = "IsOnline";
		public const int LastActivityBeforeOfflineMinutes = 10;
	}
}
