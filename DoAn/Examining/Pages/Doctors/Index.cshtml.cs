using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Entities.PatientAggregate;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Services;
using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using ApplicationCore;
namespace Examining.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private int pageSize = 3;
        private readonly IDoctorService _service;
        public IndexModel(IDoctorService service)
        {
            _service = service;
        } 

        // [BindProperty(SupportsGet = true)]
        // public string DoctorPhone { get; set; }

        public SelectList Names { get; set; }

        public PaginatedList<DoctorsDTO> ListDoctor { get; set; }

        public void OnGet(string searchString, int pageIndex = 1)
        {
            ViewData["searchString"] = searchString;

            var names = _service.GetNames();
            int count;
            var doctors = _service.GetDoctors(pageIndex , pageSize , out count);

            if (!string.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(m => m.DoctorName.Contains(searchString));
            }
            // if (!string.IsNullOrEmpty(DoctorPhone))
            // {
            //     doctors = doctors.Where(m => m.Phone == DoctorPhone);
            // }

            
            Names = new SelectList(names.Distinct().ToList());
            ListDoctor = new PaginatedList<DoctorsDTO>(doctors, pageIndex, pageSize, count);
        }
       
        
    }
}
