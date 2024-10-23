using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Helpers;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Pages
{
    public class PersonalInformationModel : PageModel
    {
        [BindProperty]
        public PersonalInformation PersonalInfo { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve personal information from session or create a new one
            PersonalInfo = HttpContext.Session.Get<PersonalInformation>("PersonalInfo") ?? new PersonalInformation();
            return Page();
        }

        public IActionResult OnPost()
        {
            // Save the PersonalInfo object to session
            HttpContext.Session.Set("PersonalInfo", PersonalInfo);

            // Redirect to the next page
            return RedirectToPage("/NextPage");
        }
    }
}
