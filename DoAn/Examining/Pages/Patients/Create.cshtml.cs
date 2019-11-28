using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.PatientAggregate;
namespace Examining.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly IPatientService _service;

        public CreateModel(IPatientService servie)
        {
            _service = servie;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreatePatient(Patient);

            return RedirectToPage("./Index");
        }
    }
}
