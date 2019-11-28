using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
namespace ApplicationCore.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
         IEnumerable<string> GetNames();
    }
}