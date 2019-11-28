using ApplicationCore.Entities.DoctorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configuration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor> {
    public void Configure(EntityTypeBuilder<Doctor> builder) {
        //builder.ToTable("Data");

        builder.HasKey(i => i.DoctorId);

        builder.Property(i => i.DoctorName)
            .HasMaxLength(40)
            .IsRequired(true);

        builder.Property(i => i.Gender)
            .IsRequired(true);

        builder.Property(i => i.Phone)
            .HasMaxLength(10)
            .IsRequired(true);
        }
    }
}