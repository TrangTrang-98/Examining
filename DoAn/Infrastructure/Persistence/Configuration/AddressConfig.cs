using ApplicationCore.Entities.PatientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Configuration
{
     public class AddressConfig : IEntityTypeConfiguration<Address> {
    public void Configure(EntityTypeBuilder<Address> builder) {
       // builder.ToTable("Data");

        builder.HasNoKey();

        builder.Property(i => i.NumHouse)
            .HasMaxLength(40)
            .IsRequired(true);

        builder.Property(i => i.Street)
            .HasMaxLength(84)
            .IsRequired(true);

        builder.Property(i => i.District)
            .IsRequired(true);

        builder.Property(i => i.City)
            .HasMaxLength(10)
            .IsRequired(true);

        builder.Property(i => i.Country)
            .HasMaxLength(10)
            .IsRequired(true);
    }
}
}