using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.DoctorAggregate;
namespace Examining.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly IDoctorService _service;

        public CreateModel(IDoctorService servie)
        {
            _service = servie;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreateDoctor(Doctor);

            return RedirectToPage("./Index");
        }
    }
}
