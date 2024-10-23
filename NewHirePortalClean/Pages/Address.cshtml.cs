using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System.Threading.Tasks;

namespace NewHirePortalClean.Pages
{
    public class AddressModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Address Address { get; set; }

        public AddressModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save Address (which includes EmployeeInformation fields now)
            _context.Addresses.Add(Address);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Information saved successfully!";
            return RedirectToPage("/SuccessPage");  // Redirect after successful save
        }
    }
}
