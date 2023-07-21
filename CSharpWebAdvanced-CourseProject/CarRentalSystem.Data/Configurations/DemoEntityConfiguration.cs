namespace CarRentalSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class DemoEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        //TODO: relations and data
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // builder.HasData(this.GenerateCars());
            throw new NotImplementedException();
        }
    }
}
