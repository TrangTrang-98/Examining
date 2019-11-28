using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Services;
using ApplicationCore.DTO;
namespace Examining.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private int pageSize = 3;
        private readonly IPatientService _service;
        public IndexModel(IPatientService service)
        {
            _service = service;
        }
        // [BindProperty(SupportsGet = true)]
        // public string PatientName { get; set; }

        public SelectList Names { get; set; }
        public PaginatedList<PatientsDTO> ListPatient { get;set; }
       
        public void OnGet(string searchString, int pageIndex = 1)
        {
            ViewData["searchString"] = searchString;

            
            var names = _service.GetNamePatients();
        
            int count;
            var patients = _service.GetPatients(pageIndex, pageSize, out count);

            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(m => m.PatientName.Contains(searchString));
             }
            // if (!string.IsNullOrEmpty(MovieGenre))
            // {
            //     movies = movies.Where(m => m.Genre == MovieGenre);
            // }

            Names = new SelectList(names.Distinct().ToList());
            ListPatient = new PaginatedList<PatientsDTO>(patients, pageIndex, pageSize, count);
        }
       
        
    }
}
