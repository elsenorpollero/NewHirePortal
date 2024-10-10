using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System;
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
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
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

            var employeeToUpdate = await _context.Employees.FindAsync(Employee.Id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            employeeToUpdate.IsApplicationComplete = Employee.IsApplicationComplete;
            employeeToUpdate.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToPage("/ManageApplications");
        }
    }
}
