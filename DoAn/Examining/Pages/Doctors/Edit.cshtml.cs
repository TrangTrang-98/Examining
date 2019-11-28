using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.DoctorAggregate;
namespace Examining.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly IDoctorService _service;

        public EditModel(IDoctorService servie)
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
                _service.UpdateDoctor(Doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.DoctorId))
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

        private bool DoctorExists(string id)
        {
            return _service.GetDoctor(id) != null;
        }
    }
}
