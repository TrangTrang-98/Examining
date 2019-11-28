using ApplicationCore.Interfaces;
using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using System.Linq;
namespace Infrastructure.Persistence.Repository
{
    public class DoctorRepository : EFRepository<Doctor>,  IDoctorRepository
    {
       public DoctorRepository(RegisterContext context) : base(context)
       {
           
       }

        public IEnumerable<string> GetNames()
        {
            return Context.Doctors
                            .Select(m => m.DoctorName)
                            .Distinct().ToList();
        }

        protected new RegisterContext Context => base.Context as RegisterContext;
    }
    
}