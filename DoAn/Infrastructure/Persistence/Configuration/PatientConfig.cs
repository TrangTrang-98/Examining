using ApplicationCore.Entities.PatientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Configuration
{
     public class PatientConfig : IEntityTypeConfiguration<Patient> {
    public void Configure(EntityTypeBuilder<Patient> builder) {
        //builder.ToTable("Patients");

        //var ownedPatient = entity.OwnsOne(x => x.Patient);

        builder.HasKey(i => i.PatientId);

        builder.Property(i => i.PatientName)
            .HasMaxLength(40)
            .IsRequired(true);

        builder.Property(i => i.Gender)
            .HasMaxLength(84)
            .IsRequired(true);

        builder.Property(i => i.Birthday)
            .IsRequired(true);
        
        // builder.OwnsOne(i => i.Address)
        //      .Property(x => x.NumHouse).HasColumnName("NumHouse");

        // builder.OwnsOne(x => x.Address)
        //     .Property(x => x.Street).HasColumnName("Street");

        // builder.OwnsOne(x => x.Address)
        //     .Property(x => x.District).HasColumnName("District");

        // builder.OwnsOne(x => x.Address)
        //     .Property(x => x.City).HasColumnName("City");

        // builder.OwnsOne(x => x.Address)
        //     .Property(x => x.Country).HasColumnName("Country");

        builder.Property(i => i.Phone)
            .HasMaxLength(10)
            .IsRequired(true);
    }
}
}