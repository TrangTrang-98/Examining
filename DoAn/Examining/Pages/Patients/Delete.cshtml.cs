using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Services;
namespace Examining.Pages.Patients
{
    
    public class DeleteModel : PageModel
    {
        private readonly IPatientService _service;

        public DeleteModel(IPatientService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = _service.GetPatient(id ?? default(string));

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = _service.GetPatient(id ?? default(string));

            if (Patient != null)
            {
                _service.DeletePatient(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
