using AutoMapper;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
namespace ApplicationCore.Mapping
{
    // using mapping to tranform data from Patient to PatientDTO 
    public class MappingProfile : Profile
    {
     public MappingProfile()
     {
            CreateMap<Patient, PatientsDTO>();
            CreateMap<Doctor, DoctorsDTO>();

     }   
    }
}