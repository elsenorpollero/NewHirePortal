using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Models;
using NewHirePortalClean.Helpers; // If you created SessionExtensions in the Helpers namespace

namespace NewHirePortalClean.Pages
{
    public class NewHireFormModel : PageModel
    {
        [BindProperty]
        public PersonalInformation PersonalInfo { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToPage("/Login");
            }

            // Retrieve existing data from session if available
            PersonalInfo = HttpContext.Session.Get<PersonalInformation>("PersonalInfo") ?? new PersonalInformation();
            return Page();
        }

        public IActionResult OnPost(string formaction)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save PersonalInfo to session
            HttpContext.Session.Set("PersonalInfo", PersonalInfo);

            if (formaction == "/EmploymentHistory")
            {
                return RedirectToPage("/EmploymentHistory");
            }
            else if (formaction == "/Splash")
            {
                return RedirectToPage("/Splash");
            }
            else
            {
                return Page();
            }
        }
    }
}
