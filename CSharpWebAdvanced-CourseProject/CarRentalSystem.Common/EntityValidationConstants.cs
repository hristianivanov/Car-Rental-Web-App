namespace CarRentalSystem.Common
{
	public static class EntityValidationConstants
	{
		public class Blog
		{
			public const int TitleMinLength = 3;
			public const int TitleMaxLength = 100;

			public const int DescriptionMinLength = 5;

			public const int ImageUrlMaxLength = 2048;
		}

		public static class Service
		{
			public const int TitleMinLength = 3;
			public const int TitleMaxLength = 100;

			public const int ImageUrlMaxLength = 2048;

			public const int TextMinLength = 5;
		}

		public static class Car
		{
			public const int ImageUrlMaxLength = 2048;

			public const int ModelMinLength = 2;
			public const int ModelMaxLength = 50;

			public const int ConsumptionMinValue = 0;
			public const int ConsumptionMaxValue = 50;

			public const int PassengerSeatsMinValue = 2;
			public const int PassengerSeatsMaxValue = 8;

			public const int SafetyMinValue = 1;
			public const int SafetyMaxValue = 5;

			public const int MileageMinValue = 0;
			public const int MileageMaxValue = 1_000_000;

			public const int YearMinValue = 1970;
			public const int YearMaxValue = 2023;

			public const string PricePerDayMinValue = "0";
			public const string PricePerDayMaxValue = "2000";
		}

		public static class Make
		{
			public const int MakeMinLength = 3;
			public const int MakeMaxLength = 20;

			public const int NewInnovationMaxLength = 255;
		}

		public static class Customer
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 50;

			public const int LastNameMinLength = 3;
			public const int LastNameMaxLength = 50;

		}

		public static class Address
		{
			public const int StreetMinLength = 3;
			public const int StreetMaxLength = 255;

			public const int ZipMinLength = 4;
			public const int ZipMaxLength = 15;
		}

		public static class Contact
		{
			public const int EmailMinLength = 3;
			public const int EmailMaxLength = 255;

			public const int PhoneNumberMinLength = 8;
			public const int PhoneNumberMaxLength = 20;
		}
	}
}
