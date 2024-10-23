using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Pages
{
    public class EmployeeInformationModel : PageModel
    {
        private readonly AppDbContext _context;

        // Property for data binding
        [BindProperty]
        public EmployeeInformation EmployeeInfo { get; set; }

        public EmployeeInformationModel(AppDbContext context)
        {
            _context = context;
        }

        // OnGet method to handle the initial page load
        public void OnGet()
        {
            // Optional: Initialize EmployeeInfo if needed
            if (EmployeeInfo == null)
            {
                EmployeeInfo = new EmployeeInformation();
            }
        }

        // OnPost method to handle form submissions
        public async Task<IActionResult> OnPostAsync(string formaction)
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the same page if validation fails
            }

            try
            {
                _context.EmployeeInformation.Add(EmployeeInfo); // Save EmployeeInfo to the database
                await _context.SaveChangesAsync();

                // Return the correct response based on which button is pressed
                if (formaction == "SaveAndContinue")
                {
                    return RedirectToPage("/Address");
                }
                else if (formaction == "Back")
                {
                    return RedirectToPage("/Splash");
                }
                else
                {
                    TempData["SaveSuccess"] = true;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Log the error if saving fails
                Console.WriteLine($"Error saving Employee Information: {ex.Message}");
                return Page();
            }
        }
    }
}
