using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using NewHirePortalClean.Models; // Assuming your Application model is in the Models folder
using System.ComponentModel.DataAnnotations; // For adding validation attributes

namespace NewHirePortalClean.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        public bool RememberMe { get; set; } = false;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid (missing fields, etc.), return to the page and show errors.
                return Page();
            }

            // Handle normal login logic here
            // Assuming you validate the user credentials, e.g., against a database.

            if (Username == "admin" && Password == "admin123")
            {
                // Log in the user and set the session
                HttpContext.Session.SetString("Username", Username);

                if (RememberMe)
                {
                    // Optionally store the "RememberMe" choice in cookies.
                    Response.Cookies.Append("RememberedUsername", Username, new CookieOptions { Expires = System.DateTimeOffset.Now.AddDays(30) });
                }

                return RedirectToPage("/NewHireForm"); // Redirect to the application page after successful login
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page(); // If credentials are invalid, return to the page with an error.
            }
        }

        // Updated method to handle guest login
        public IActionResult OnGetGuestLogin()
        {
            // Set the session for the guest user
            HttpContext.Session.SetString("UserName", "Guest");

            // Redirect the guest user to the New Hire Form
            return RedirectToPage("/NewHireForm");

            // Test if this method is triggered
            return Content("Guest Login triggered!");

        }
    }
}
