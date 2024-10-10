using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewHirePortalClean.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Admin credentials
            const string adminUsername = "admin";
            const string adminPassword = "admin123";

            if (Username == adminUsername && Password == adminPassword)
            {
                // Set session for admin authentication
                HttpContext.Session.SetString("IsAdminAuthenticated", "true");
                return RedirectToPage("/AdminPortal");
            }
            else if (Username == "testuser" && Password == "password123")
            {
                // Set session for normal user authentication
                HttpContext.Session.SetString("IsAuthenticated", "true");
                return RedirectToPage("/NewHireForm");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
