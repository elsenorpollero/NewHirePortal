using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using NewHirePortalClean.Models;

public class EmploymentHistoryModel : PageModel
{
    [BindProperty]
    public EmploymentHistory EmploymentInfo { get; set; }

    // OnGet method to load the page
    public void OnGet()
    {
        EmploymentInfo = new EmploymentHistory(); // Initialize EmploymentInfo
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
            return RedirectToPage("/NextPage"); // Navigate to the next page
        }
        else if (formaction == "NewHireForm")
        {
            return RedirectToPage("/NewHireForm"); // Navigate to the New Hire Form page
        }

        return Page();
    }
}
