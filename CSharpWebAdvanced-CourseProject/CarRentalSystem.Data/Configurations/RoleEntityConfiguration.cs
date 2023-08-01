namespace CarRentalSystem.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class RoleEntityConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
		{
			builder.HasData(GetRoles());
		}

		private IEnumerable<IdentityRole<Guid>> GetRoles()
		{
			return new HashSet<IdentityRole<Guid>>()
			{
				new IdentityRole<Guid>()
				{
					Id = Guid.Parse("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
					Name = "Master Administrator",
					NormalizedName = "MASTER ADMINISTRATOR"
				}
			};
		}
	}
}
