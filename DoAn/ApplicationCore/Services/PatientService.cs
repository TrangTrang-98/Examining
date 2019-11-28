using ApplicationCore.Interfaces;
using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.Specifications;
using ApplicationCore;
using AutoMapper;
using System.Threading.Tasks;
// service : using to implement get, add, delete, update
namespace ApplicationCore.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public  IEnumerable<string> GetNamePatients()
        {  
               return _unitOfWork.Patients.GetNames();
        }
         public Patient GetPatient(string id)
         {
             return _unitOfWork.Patients.GetBy(id);
         }

         public  IEnumerable<PatientsDTO> GetPatients(int pageIndexs, int pageSize, out int count)// out chi lay ra
         {
              count = 4;
             // return _unitOfWork.Patients.GetAll();


             var patientSpecPaging = new PatientSpecification(pageIndexs, pageSize);
            
            var patients =  _unitOfWork.Patients.Find(patientSpecPaging);
        
                return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientsDTO>>(patients);
            }
         
         public void CreatePatient(Patient patient)
         {
             _unitOfWork.Patients.Add(patient); 
             _unitOfWork.Complete(); 
         }
         public void UpdatePatient(Patient patient)
         {
            _unitOfWork.Patients.Update(patient);
            _unitOfWork.Complete();   
         }
         public void DeletePatient(string id)
         {
             var patient = _unitOfWork.Patients.GetBy(id);

            if (patient == null) return;

            _unitOfWork.Patients.Remove(patient);

            _unitOfWork.Complete();
         }

    }
}
