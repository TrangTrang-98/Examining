using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class DataSeed
    {
        public static void Initialize(RegisterContext context)
        {
           
            context.Database.EnsureCreated();
            
            // DB has seeded
            if (!context.Patients.Any())
            { 
                context.Patients.AddRange(
                
                    new Patient("B001", "Nguyen Ha", Gender.female, System.DateTime.Parse("1989-12-6"), "0978546234"),
                
                    new Patient("B004", "Van Duc", Gender.male, System.DateTime.Parse("1996-8-9"), "09794567895"),
                    new Patient("T008", "Văn Trung", Gender.male,  System.DateTime.Parse("1996-8-10"), "09794567878"),
                    new Patient("T745",  "Nguyễn Thị Hoa", Gender.female, System.DateTime.Parse("1996-10-9"), "03694567895")
                );
                context.SaveChanges();
            }
            if (!context.Doctors.Any()) 
            {
                context.Doctors.AddRange(
                     
                    new Doctor("S001", "Nguyen A", Gender.female , "0334578965"),
                    new Doctor("H008", "Nguyen B", Gender.male,  "0975658745")
                    );

                context.SaveChanges();

            }
            
        }
    }
}