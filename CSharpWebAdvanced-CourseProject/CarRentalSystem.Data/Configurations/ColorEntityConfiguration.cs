namespace CarRentalSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
	{
		public void Configure(EntityTypeBuilder<Color> builder)
		{
			builder.HasData(this.GenerateColors());
		}

		private ICollection<Color> GenerateColors()
		{
			var colors = new HashSet<Color>();

			colors.Add(new Color()
			{
				Id = 1,
				Name = "Ibis White",
				ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/T9T9.png"
			});
			colors.Add(new Color()
			{
				Id = 2,
				Name = "Daytona Grey Pearl effect",
				ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/6Y6Y.png"
			});
			colors.Add(new Color()
			{
				Id = 3,
				Name = "Ascari Blue Metallic",
				ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/9W9W.png"
			});
			colors.Add(new Color()
			{
				Id = 4,
				Name = "Tango Red Metallic",
				ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/Y1Y1.png"
			});
			colors.Add(new Color()
			{
				Id = 5,
				Name = "Tactics Green Metallic",
				ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/V0V0.png"
			});

			return colors;
		}
	}
}
