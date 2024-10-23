using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Pages
{
    public class EmploymentHistoryModel : PageModel // Changed the class name to match the page
    {
        // Property to hold the current user information (optional)
        public string CurrentUser { get; set; } = "Guest"; // Default to "Guest" if no session

        // Bind Employment Information to the form
        [BindProperty]
        public EmploymentHistory EmploymentInfo { get; set; }

        // OnGet method to handle page loading
        public void OnGet()
        {
            EmploymentInfo = new EmploymentHistory(); // Initialize the model for the page
        }

        // OnPost method to handle form submission
        public IActionResult OnPost(string formaction)
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the page with validation errors
            }

            if (formaction == "NextPage")
            {
                return RedirectToPage("/NextPage"); // Correct syntax
            }
            else if (formaction == "NewHireForm")
            {
                return RedirectToPage("/NewHireForm"); // Correct syntax
            }

            return Page();
        }
    }
}
