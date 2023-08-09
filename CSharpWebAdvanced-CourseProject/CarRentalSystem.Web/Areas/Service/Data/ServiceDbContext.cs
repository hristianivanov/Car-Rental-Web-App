namespace CarRentalSystem.Web.Areas.Service.Data
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Service = Model.Service;

	public class ServiceDbContext : DbContext
	{
		public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
			: base(options)
		{

		}

		public DbSet<Service> Services { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ServiceConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
