using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.PatientAggregate;
namespace Examining.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly IPatientService _service;

        public EditModel(IPatientService servie)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _service.UpdatePatient(Patient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.PatientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PatientExists(string id)
        {
            return _service.GetPatient(id) != null;
        }
    }
}
