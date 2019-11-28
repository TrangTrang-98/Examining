using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Services;
namespace Examining.Pages.Doctors
{
    
    public class DeleteModel : PageModel
    {
        private readonly IDoctorService _service;

        public DeleteModel(IDoctorService servie)
        {
            _service = servie;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = _service.GetDoctor(id ?? default(string));

            if (Doctor == null)
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

            Doctor = _service.GetDoctor(id ?? default(string));

            if (Doctor != null)
            {
                _service.DeleteDoctor(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
