using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Pages
{
    public class NewHireFormModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public PersonalInformation PersonalInfo { get; set; }

        public NewHireFormModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Any data loading logic if needed
        }

        public IActionResult OnPost(string formaction)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the form data before determining the action
            _context.PersonalInformation.Update(PersonalInfo);
            _context.SaveChanges();

            // Handle the button actions based on the formaction value
            if (formaction == "Next")
            {
                // Redirect to the Address page (next page)
                return RedirectToPage("/Address");
            }
            else if (formaction == "Back")
            {
                // Redirect to the Splash page (previous page)
                return RedirectToPage("/Splash");
            }
            else if (formaction == "Save")
            {
                // Stay on the same page after saving
                TempData["Message"] = "Form data saved.";
                return Page();
            }
            else if (formaction == "SaveAndContinue")
            {
                // Save and redirect to the Address page
                TempData["Message"] = "Form data saved and continuing.";
                return RedirectToPage("/Address");
            }

            // Default action is to remain on the same page
            return Page();
        }
    }
}
