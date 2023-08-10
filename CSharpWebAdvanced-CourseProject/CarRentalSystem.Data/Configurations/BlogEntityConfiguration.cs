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
			var cars = new HashSet<Blog>();

			cars.Add(new Blog()
			{
				Id = Guid.NewGuid(),
				Title = "Why Lead Generation Is Key For Business Growth",
				Description = "A small river named Duden flows by" +
				              " their place and supplies it with the necessary regelialia. " +
				              "It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",
				CreaterId = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				ImageUrl = "https://localhost:7263/images/blog/image_1.jpg",
				CreatedOn = new DateTime(2019,10,29),
			});
			

			return cars;
		}

	}
}
