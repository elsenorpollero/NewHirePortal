using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NewHirePortalClean.Pages
{
    public class EditApplicationModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditApplicationModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeApplication Application { get; set; }  // Ensure this is EmployeeApplication

        public IActionResult OnGet(int applicationId)
        {
            // Fetch EmployeeApplication by ID instead of EmployeeInformation
            Application = _context.EmployeeApplications.FirstOrDefault(a => a.Id == applicationId);

            if (Application == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var applicationInDb = _context.EmployeeApplications.FirstOrDefault(a => a.Id == Application.Id);

            if (applicationInDb == null)
            {
                return NotFound();
            }

            // Update properties of application
            applicationInDb.Status = Application.Status;
            applicationInDb.LastUpdated = System.DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToPage("/AdminPortal");
        }
    }
}
