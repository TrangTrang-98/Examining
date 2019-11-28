using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Configuration;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Entities;
using ApplicationCore.Entities.PatientAggregate;
namespace Infrastructure.Persistence
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients{get; set;}
        public DbSet<Doctor> Doctors{get; set;}
        
        // public DbSet<Enrollment> Enrollments{get; set;}
        
        protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new PatientConfig());
        builder.ApplyConfiguration(new DoctorConfig());
       // builder.ApplyConfiguration(new EnrollmentConfig()); // list benh nhan dang ki kham benh
        
        //  builder.Entity<Enrollment>()
        //          .HasKey(e => new { e.patientId, e.doctorId});
        
        //  builder.Entity<Patient>()
        //          .HasMany(p => p.Enrollment);
    
        
        }

        
        
    }
}