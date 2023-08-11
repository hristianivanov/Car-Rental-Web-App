namespace CarRentingSystem.Services.Mocks
{
	using Moq;
	using CarRentalSystem.Services.Data.Interfaces;
	using CarRentalSystem.Web.ViewModels.Home;

	public class CarServiceMock
	{
		public static ICarService Instance
		{
			get
			{
				var carServiceMock = new Mock<ICarService>();

				carServiceMock
					.Setup(c => c.LastCarsAsync(It.IsAny<int>()))
					.ReturnsAsync(new List<IndexViewModel>());

				return carServiceMock.Object;
			}
		}
	}
}