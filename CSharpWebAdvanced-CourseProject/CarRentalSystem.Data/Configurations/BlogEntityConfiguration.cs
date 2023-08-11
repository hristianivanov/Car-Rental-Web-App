using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Data.Configurations
{
	using CarRentalSystem.Data.Models.Enums;
	using Microsoft.EntityFrameworkCore;

	using Models;

	public class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder
				.Property(c => c.CreatedOn)
				.HasDefaultValueSql("GETDATE()");

			builder
				.Property(c => c.IsActive)
				.HasDefaultValue(true);

			builder.HasData(this.GenerateBlogs());
		}
		private ICollection<Blog> GenerateBlogs()
		{
			var blogs = new HashSet<Blog>();

			blogs.Add(new Blog()
			{
				Id = Guid.NewGuid(),
				Title = "What to Expect When You Rent a Bugatti in Dubai: A Guide for First-Timers",
				Description = "Dubai is renowned for its opulence and luxury, " +
				              "and one of the ultimate symbols of extravagance is cruising through the city in a Bugatti. " +
				              "Known for its sleek design, unmatched power, and jaw-dropping " +
				              "speed, the Bugatti is the epitome of automotive excellence. If you’re considering " +
				              "a Bugatti rental Dubai for the first time, here’s what you can " +
				              "expect from this unforgettable experience.Unparalleled Performance" +
				              "When you opt for a Bugatti hire, you’re not just renting a " +
				              "car; you’re gaining access to a supercar that is in a league of its " +
				              "own. The Bugatti’s engine roars to life, producing an adrenaline-pumping symphony of " +
				              "power. As you press the accelerator, you’ll feel a surge of acceleration that pins " +
				              "you to the seat. With its impressive horsepower and exceptional handling, the Bugatti delivers a driving " +
				              "experience like no other. Be prepared to be amazed by its speed, agility, and " +
				              "the flawless way it hugs the road.Exquisite Design and Craftsmanship" +
				              "Bugatti cars are known for their striking beauty and meticulous attention to detail. From the " +
				              "moment you set eyes on a Bugatti, you’ll be captivated by its elegant curves and aerodynamic " +
				              "profile. The interior is equally breathtaking, with luxurious materials, handcrafted " +
				              "finishes, and state-of-the-art technology. Every inch of a Bugatti exudes sophistication " +
				              "and refinement, making it an absolute pleasure to drive and admire.",
				CreaterId = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				ImageUrl = "https://localhost:7263/images/blog/image_1.jpg",
				CreatedOn = new DateTime(2019,10,29),
			});
			blogs.Add(new Blog()
			{
				Id = Guid.NewGuid(),
				Title = "Why Renting a Lamborghini Aventador is Worth Every Penny",
				Description = "If you have ever dreamed of feeling the luxurious thrill of having Italian " +
				              "engineering at your fingertips, then renting a Lamborghini Aventador could be the " +
				              "perfect way to live out that dream. This ultimate driving experience comes with everything " +
				              "from an innovative design and cutting-edge powertrain, to excellent handling capabilities and " +
				              "advanced safety features.But beyond some fantastic performance numbers, when you rent a" +
				              " Lamborghini Aventador Dubai, you enjoy access to exclusive amenities and services that" +
				              " give you an unforgettable drive every time. So if you are looking for something extraordinary " +
				              "behind the wheel, read on as we explore why renting a Lamborghini Aventador is worth every" +
				              " penny!1- Turn Heads Everywhere You Go:As one of the most iconic" +
				              " cars on the market, you can be sure that the Lamborghini Aventador will not fail to" +
				              " turn heads when you drive it. With its sharp lines and bold design, this car is an instant " +
				              "showstopper – giving you a chance to make a statement wherever you go.2- Feel Unmatched" +
				              " Power:When you rent a Lamborghini Aventador, you do not just get an impressive look" +
				              ", but also exceptional performance. Powered by a V12 engine with up to 740 horsepower, this " +
				              "car can take your driving experience to another level as it races from 0-60 in just 2.9 seconds!" +
				              "3- Enjoy Advanced Technology:The Lamborghini Aventador doesn’t just look great, bu" +
				              "t it also comes with several advanced technologies to enhance your drive. From a 12.3-inch TF" +
				              "T digital instrument cluster and an 8.4-inch touchscreen infotainment system to adaptive suspen" +
				              "sion and active aerodynamics – this car has it all!4- Receive Personalized Se" +
				              "rvice:When you rent a Lamborghini Aventador, you get access to the exc" +
				              "lusive services of the dealership. From 24/7 roadside assistance and custom de" +
				              "tailing packages to personalized concierge services – they have got everything cov" +
				              "ered for you so that you can enjoy a hassle-free experience every time!5- Experien" +
				              "ce Luxury Like Never Before:Renting a Lamborghini Aventador allows you to expe" +
				              "rience true luxury like never before. From plush leather seating and high-end audio systems " +
				              "to aerodynamic body styling and other premium features – it is the perfect car for those who" +
				              " want an extraordinary driving experience.6- Unbeatable Price:Of course, the best" +
				              " part of all is that you can hire a Lamborghini Aventador in Dubai for an unbeatable price." +
				              " Whether you choose to rent hourly or long-term, you will get access to exclusive " +
				              "offers and competitive rates – making it well worth every penny!",
				ImageUrl = "https://www.digitaltrends.com/wp-content/uploads/2020/01/lamborghini_aventador_svj_roadster_1.jpg?fit=1500%2C1000&p=1",
				CreaterId = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				CreatedOn = new DateTime(2023, 6, 22),
			});
			blogs.Add(new Blog()
			{
				Id = Guid.NewGuid(),
				Title = "Road Trip Ready: Preparing for Your Car Rental Adventure",
				Description = "Embarking on a road trip is an exhilarating experience filled with freedom, " +
				              "adventure, and the open road stretching ahead. Proper preparation is vital to " +
				              "ensuring a smooth and enjoyable journey if you are planning a road trip and opting " +
				              "for a car rental. In this blog, we will guide you through essential steps and tips to" +
				              " follow when you hire a luxury car in Dubai. From choosing the right vehicle to planning" +
				              " your route and packing smartly, let’s dive into the details and make your road trip an" +
				              " unforgettable experience.Choose the Right Rental VehicleThe first step in preparing" +
				              " for your car rental adventure is selecting the ideal vehicle for your needs. Consider" +
				              " factors such as the number of passengers, luggage space requirements, and the terrain" +
				              " you will encounter. Whether you opt for a spacious SUV for a family trip, a fuel-efficient " +
				              "sedan for a solo adventure, or a luxurious convertible for a stylish getaway, choose a vehicle" +
				              " that suits your preferences and enhances your overall road trip experience.Research " +
				              "and Compare Rental Companies. With numerous car rental companies available, conducting " +
				              "thorough research and comparing their offerings is essential. Look for reputable" +
				              " companies that provide reliable vehicles, transparent pricing, and excellent" +
				              " customer service. Read reviews, check for hidden fees, and compare rental rates " +
				              "to ensure you get the best value. Additionally, consider rental policies, such as" +
				              " mileage limitations and insurance coverage, to make an informed decision.",
				ImageUrl = "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1562255176/autoexpress/porsche-911-c4-cabriolet-1-front-cornering.jpg",
				CreaterId = Guid.Parse("F06D4765-779A-4766-EB64-08DB8A42133C"),
				CreatedOn = new DateTime(2022, 5, 5),
			});
			blogs.Add(new Blog()
			{
				Id = Guid.NewGuid(),
				Title = "Unleash Your Inner Adventurer: Rent a G Wagon for Off-Road Excursions",
				Description = "Are you tired of the ordinary? Do you crave thrilling adventures that push" +
				              " your boundaries and ignite your sense of wanderlust? Look no further! Renting" +
				              " a G Wagon for off-road excursions is the perfect way to unleash your inner" +
				              " adventurer and embark on unforgettable journeys into the great outdoors. With " +
				              "its rugged design, exceptional performance, and luxurious features, the G Wagon " +
				              "is the ultimate companion for those seeking thrilling off-road experiences.This " +
				              "blog will explore why you should rent G Wagon for off-road excursions and what " +
				              "makes it an absolute game-changer. So fasten your seat belts and get ready for " +
				              "an adrenaline-pumping ride!Unparalleled Off-Road Capability. When it comes to" +
				              " conquering challenging terrains, the G Wagon is in a league of its own. With " +
				              "its robust build, advanced four-wheel-drive system, and high ground clearance, " +
				              "this formidable machine is built to handle any off-road obstacle that comes its " +
				              "way. So whether you are navigating steep inclines, crossing rocky landscapes, or " +
				              "fording through water bodies, the G Wagon’s off-road capability ensures that you" +
				              " stay in control and easily reach your destination.",
				ImageUrl = "https://i0.wp.com/www.car-revs-daily.com/wp-content/uploads/2014/10/2015-BMW-X6-M-27.jpg?fit=2625%2C1281&ssl=1",
				CreaterId = Guid.Parse("F06D4765-779A-4766-EB64-08DB8A42133C"),
				CreatedOn = new DateTime(2023, 7, 1),
			});

			return blogs;
		}

	}
}
