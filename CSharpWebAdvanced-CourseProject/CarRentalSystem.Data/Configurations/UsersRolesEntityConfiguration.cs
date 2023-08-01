using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	public class UsersRolesEntityConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
		{
			builder.HasData(GetUserRoles());
		}

		private IEnumerable<IdentityUserRole<Guid>> GetUserRoles()
		{
			return new HashSet<IdentityUserRole<Guid>>()
			{
				new IdentityUserRole<Guid>()
				{
					RoleId = Guid.Parse("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
					UserId = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				}
			};
		}
	}
}
