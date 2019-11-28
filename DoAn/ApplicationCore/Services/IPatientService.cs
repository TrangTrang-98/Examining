using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ApplicationCore.Services
{
    public interface IPatientService
    {
        Patient GetPatient(string id);
        IEnumerable<PatientsDTO> GetPatients(int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetNamePatients(); // ds ten benh nhan(de loc)
        void CreatePatient(Patient Patient); // dang ki benh nhan
        void UpdatePatient(Patient Patient);
        void DeletePatient(string id);
    }
}