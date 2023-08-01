using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Data.Configurations
{
	using CarRentalSystem.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	public class UserEntityConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(this.GenerateUsers());
		}

		private IEnumerable<User> GenerateUsers()
		{
			var users = new HashSet<User>();
			var hasher = new PasswordHasher<User>();

			User user;
			user = new User()
			{
				Id = Guid.Parse("8A5EDC49-7490-493F-2F01-08DB8A416485"),
				UserName = "admin@gmail.com",
				NormalizedUserName = "ADMIN@GMAIL.COM",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				FirstName = "hris",
				LastName = "ivanov",
				SecurityStamp = Guid.NewGuid().ToString(),
				PhoneNumber = "0895969391",
			};
			user.PasswordHash = hasher.HashPassword(user, "admin");
			users.Add(user);

			user = new User()
			{
				Id = Guid.Parse("F06D4765-779A-4766-EB64-08DB8A42133C"),
				UserName = "defi@gmail.com",
				NormalizedUserName = "DEFI@GMAIL.COM",
				Email = "defi@gmail.com",
				NormalizedEmail = "DEFI@GMAIL.COM",
				FirstName = "defne",
				LastName = "ahmedova",
				SecurityStamp = Guid.NewGuid().ToString(),
				PhoneNumber = "0888888391",
			};
			user.PasswordHash = hasher.HashPassword(user, "123456");
			users.Add(user);

			user = new User()
			{
				Id = Guid.Parse("F2525385-0162-4B42-8FA5-08DB8A43496A"),
				UserName = "pesho_petrov@yahoo.com",
				NormalizedUserName = "PESHO_PETROV@YAHOO.COM",
				Email = "pesho_petrov@yahoo.com",
				NormalizedEmail = "PESHO_PETROV@YAHOO.COM",
				FirstName = "pesho",
				LastName = "petrov",
				SecurityStamp = Guid.NewGuid().ToString(),
				PhoneNumber = "0878559310",
			};
			user.PasswordHash = hasher.HashPassword(user, "123456");
			users.Add(user);

			return users;
		}
	}
}
