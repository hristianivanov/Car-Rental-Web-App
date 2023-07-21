namespace CarRentalSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MakeEntityConfiguration : IEntityTypeConfiguration<Make>
    {
	    public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(this.GenerateMakes());
        }

	    private ICollection<Make> GenerateMakes()
	    {
            var makes = new HashSet<Make>();

            makes.Add(new Make()
            {
	            Id = 1,
				Name = "Acura",
                NewInnovation = "IntelliCruise"
			});
            makes.Add(new Make()
            {
	            Id = 2,
				Name = "Alfa Romeo",
	            NewInnovation = "Active Aero Splitter"
            });
            makes.Add(new Make()
            {
	            Id = 3,
	            Name = "Audi",
	            NewInnovation = "Virtual Cockpit Plus"
			});
            makes.Add(new Make()
            {
				Id = 4,
	            Name = "BMW",
	            NewInnovation = "Gesture Control 2.0"
			});
            makes.Add(new Make()
            {
				Id = 5,
	            Name = "Bentley",
	            NewInnovation = "Self-Leveling Air Suspension"
			});
            makes.Add(new Make()
            {
				Id = 6,
	            Name = "Ferrari",
	            NewInnovation = "Side Slip Control"
			});

			return makes;
	    }
    }
}
