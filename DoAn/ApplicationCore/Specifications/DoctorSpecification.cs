using ApplicationCore.Entities.DoctorAggregate;
namespace ApplicationCore.Specifications
{
    public class DoctorSpecification : Specification<Doctor>
    {
        public DoctorSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}