using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
namespace ApplicationCore.Services
{
    public interface IDoctorService
    {
        Doctor GetDoctor(string id);
        IEnumerable<DoctorsDTO> GetDoctors(int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetNames();// ds ten bac si(de loc)
        void CreateDoctor(Doctor Doctor); // them moi bac si
        void UpdateDoctor(Doctor Doctor);
        void DeleteDoctor(string id);
    }
}