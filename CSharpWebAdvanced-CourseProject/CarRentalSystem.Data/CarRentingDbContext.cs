namespace CarRentalSystem.Data
{
    using System.Reflection;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

	using Models;

    public class CarRentingDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
	    public DbSet<Car> Cars { get; set; }
	    public DbSet<Make> Makes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<UserRentals> UsersRentals { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserRentals>()
				.HasKey(cr => new { cr.CustomerId, cr.RentalId });

			Assembly configAssembly = Assembly.GetAssembly(typeof(CarRentingDbContext)) ??
									  Assembly.GetExecutingAssembly();

			modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);
        }

    }
}