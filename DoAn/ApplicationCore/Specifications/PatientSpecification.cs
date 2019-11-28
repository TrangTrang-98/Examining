using ApplicationCore.Specifications;
using ApplicationCore.Entities.PatientAggregate;
namespace ApplicationCore.Specifications
{
    public class PatientSpecification : Specification<Patient>
    {
        public PatientSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}