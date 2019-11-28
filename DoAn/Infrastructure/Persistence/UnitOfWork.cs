using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence;
namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegisterContext _context;

        public UnitOfWork(RegisterContext context)
        {
            _context = context;
            this.Patients = new PatientRepository(context);
            this.Doctors = new DoctorRepository(context);
        }

        public IPatientRepository Patients { get; } // cung ten vơi IUnitOfWork.IPatientRepository
        public IDoctorRepository Doctors { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}