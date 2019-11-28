using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.DoctorAggregate;
namespace Examining.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly IDoctorService _service;

        public DetailsModel(IDoctorService servie)
        {
            _service = servie;
        }

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
    }
}
