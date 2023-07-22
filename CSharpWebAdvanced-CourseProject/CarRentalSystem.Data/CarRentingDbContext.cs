namespace CarRentalSystem.Data
{
    using System.Reflection;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

	using Models;

    public class CarRentingDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
		//TODO: need to add address but think of how ?
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CarColors> CarsColors { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<UserRentals> UsersRentals { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ImageData> ImageData { get; set; }

		// For now I will allow cascade deleting! If it's necessary I will prevent the cascade deletion...
		//how to add admin through db UI dbo.AspNetRoles, dbo.AspNetUserRoles
		public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CarColors>()
				.HasKey(cc => new { cc.CarId, cc.ColorId });

			modelBuilder.Entity<UserRentals>()
				.HasKey(cr => new { cr.CustomerId, cr.RentalId });

			Assembly configAssembly = Assembly.GetAssembly(typeof(CarRentingDbContext)) ??
									  Assembly.GetExecutingAssembly();

			modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

			//TODO: if u need to restrict sensitive data do it in entity configuration classes
			// but if the data is sensitive the user can have the option to delete the sensitive data about him

            //modelBuilder.Entity<CarColors>()
			//	.HasOne(cc => cc.Car)
			//	.WithMany(c => c.CarColors)
			//	.HasForeignKey(cc => cc.CarId);

			//modelBuilder.Entity<CarColors>()
			//	.HasOne(cc => cc.Color)
			//	.WithMany(c => c.CarColors)
			//	.HasForeignKey(cc => cc.ColorId);

			//modelBuilder.Entity<CustomerRentals>()
			//	.HasOne(cr => cr.Customer)
			//	.WithMany(c => c.CustomerRentals)
			//	.HasForeignKey(cr => cr.CustomerId);

			//modelBuilder.Entity<CustomerRentals>()
			//	.HasOne(cr => cr.Rental)
			//	.WithMany(r => r.CustomerRentals)
			//	.HasForeignKey(cr => cr.RentalId);
		}

    }
}