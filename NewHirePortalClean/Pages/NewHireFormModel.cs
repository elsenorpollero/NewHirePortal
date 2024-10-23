using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using NewHirePortalClean.Models;

public class NewHireFormModel : PageModel
{
    public string CurrentUser { get; set; } = "Guest";

    [BindProperty]
    public PersonalInformation PersonalInfo { get; set; }

    // OnGet method to load the page
    public void OnGet()
    {
        PersonalInfo = new PersonalInformation(); // Initialize the model
    }

    // OnPost method to handle form submissions
    public IActionResult OnPost(string formaction)
    {
        if (!ModelState.IsValid)
        {
            return Page(); // Return page with validation errors
        }

        if (formaction == "EmploymentHistory")
        {
            return RedirectToPage("EmploymentHistory"); // Redirect to Employment History page
        }
        else if (formaction == "Splash")
        {
            return RedirectToPage("Splash"); // Redirect to Splash page
        }

        return Page();
    }
}
