namespace CarRentalSystem.Web.Areas.Service.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Service = Model.Service;

	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.HasData(ServicesData());
		}

		private ICollection<Service> ServicesData()
		{
			var data = new HashSet<Service>();

			Service service;

			service = new Service()
			{
				Id = 1,
				Title = "Self Drive Car Rental",
				Text =
					"Luxury Supercar Rentals Dubai ​prides itself on being the leading prestige and performance car hire company " +
					"in the industry. At​ Luxury Supercar Rentals​, we give you the opportunity to get your pulse racing, " +
					"make a lasting impression at your next corporate or social event, or simply drive the car of your dreams. " +
					"​ We don’t just offer you a luxury car model; we also offer you a luxury car hire experience. " +
					"Our staff are fully trained to ensure your luxury car comes to you spotless and well-serviced so " +
					"you can be confident that the vehicle you’re driving is safe, performing to its highest standard, " +
					"and of prestige quality.Our luxury car rental service is tailored to suit your lifestyle whether you " +
					"want comfort, speed, economy or a combination of all three. We will source the best vehicle for you. " +
					"With a fleet of over 50 different prestige, luxury and supercars, we offer an unrivalled selection, " +
					"including exclusive models from ​Ferrari​, Lamborghini, ​Bentley​, Rolls Royce, Maserati, Mercedes​, BMW, " +
					"​Porsche​ and ​Audi​. At LSR we pride ourselves on client satisfaction, which is why we offer a superb selection " +
					"of Luxury cars at fantastic value for money prices. Our service includes exclusive benefits such as Free Pick " +
					"up & drop off anywhere in Dubai, discounts on ​long term rental hire​ and insurance included across our entire fleet.",
				ImageUrl = "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/proving.webp",
			};
			data.Add(service);

			service = new Service()
			{
				Id = 2,
				Title = "Long Term Rental",
				Text = "For long-term travel plans and replacement car needs, an affordable monthly rental from Luxury Supercar Rentals can be the ideal solution. The longer you choose to rent with Luxury Supercar Rentals, the cheaper the price becomes, " +
					   "meaning you can drive that premium rental car you’ve always wanted for a price that doesn’t" +
					   " exceed the budget.",
				ImageUrl = "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/long-term.webp",
			};
			data.Add(service);

			service = new Service()
			{
				Id = 3,
				Title = "Weddings & Special Events",
				Text =
					"We provide luxury wedding cars for your special day all year round and ensure that you make the " +
					"grandest entrance to one of the most memorable days of your life. Here at Luxury Supercars Dubai we have " +
					"an extensive fleet of luxury wedding cars available, ranging from Rolls Royce and Lamborghini to " +
					"Bentley and Mercedes. So no matter your preference we have the perfect wedding car for you.Have a look " +
					"at our collection of luxury cars and choose the one that suits your needs and requirements. If " +
					"you are confused and not sure which car you should hire for your special day, do not worry as " +
					"our expert car hire team are here to guide you every step of the way.They will ensure that the vehicle" +
					" compliments the style and theme of the occasion perfectly.Our luxury collection consists of a wide " +
					"range of the most prestigious luxury vehicles in the world. From Rolls Royce and Lamborghini to " +
					"Ferrari and Bentley. We continue to add to our collection each year and strive to have the best available.",
				ImageUrl = "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/weddings.webp"
			};
			data.Add(service);

			service = new Service()
			{
				Id = 4,
				Title = "Gift Vouchers",
				Text = "There’s no better gift than a fancy ride in Dubai’s streets. Allow your loved ones " +
					   "to feel special while riding in Dubai’s elite car collection from Luxury Supercar Rentals.Our " +
					   "offices provide gift cards and vouchers for all your occasions.Do not hesitate to " +
					   "get more information about our gift vouchers program.",
				ImageUrl = "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/gift.webp"
			};
			data.Add(service);

			return data;
		}
	}
}
