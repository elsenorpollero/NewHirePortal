using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewHirePortalClean.Pages
{
    public class SplashModel : PageModel
    {
        public IActionResult OnPostProceed()
        {
            // Redirect to the login page
            return RedirectToPage("/Login");
        }
    }
}
