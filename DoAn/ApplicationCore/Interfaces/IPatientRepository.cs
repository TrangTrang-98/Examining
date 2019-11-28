using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
namespace ApplicationCore.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
         IEnumerable<string> GetNames();
    }
}