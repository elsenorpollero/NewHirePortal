using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHirePortalClean.Pages
{
    public class AdminPortalModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminPortalModel(AppDbContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }
        public List<EmployeeApplication> Applications { get; set; }

        [BindProperty]
        public string NewUsername { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string UserRole { get; set; }

        [BindProperty]
        public string NeedsApplication { get; set; }

        public void OnGet()
        {
            // Retrieve Users and Applications from the database
            Users = _context.Users.ToList();
            Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
        }

        public async Task<IActionResult> OnPostAddUserAsync()
        {
            Console.WriteLine("OnPostAddUserAsync() called.");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid.");
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
                Users = _context.Users.ToList();
                Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
                return Page();
            }

            Console.WriteLine("Model state is valid. Adding new user.");

            var newUser = new User
            {
                Username = NewUsername,
                Password = NewPassword, // Ideally, hash passwords before storing them
                IsAdmin = UserRole == "Admin"
            };

            try
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                Console.WriteLine("New user added to the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }

            if (UserRole == "Employee" && NeedsApplication == "Yes")
            {
                Console.WriteLine("Adding new application for the user.");
                var newApplication = new EmployeeApplication
                {
                    FirstName = NewUsername.Split(' ')[0],
                    LastName = NewUsername.Split(' ').Length > 1 ? NewUsername.Split(' ')[1] : string.Empty,
                    Status = "Pending",
                    IsComplete = false,
                    LastUpdated = System.DateTime.Now
                };

                try
                {
                    _context.EmployeeApplications.Add(newApplication);  // Changed to EmployeeApplications
                    await _context.SaveChangesAsync();
                    Console.WriteLine("New application added to the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding application: {ex.Message}");
                }
            }

            Users = _context.Users.ToList();
            Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                Users = _context.Users.ToList();
                Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            Console.WriteLine("User deleted successfully.");

            // Reload data and redirect
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteApplicationAsync(int applicationId)
        {
            var application = _context.EmployeeApplications.FirstOrDefault(a => a.Id == applicationId);  // Changed to EmployeeApplications
            if (application == null)
            {
                Console.WriteLine("Application not found.");
                Users = _context.Users.ToList();
                Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
                ModelState.AddModelError(string.Empty, "Application not found.");
                return Page();
            }

            _context.EmployeeApplications.Remove(application);  // Changed to EmployeeApplications
            await _context.SaveChangesAsync();
            Console.WriteLine("Application deleted successfully.");

            // Reload data and redirect
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditUserAsync(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                Users = _context.Users.ToList();
                Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            // Update user details
            user.Username = NewUsername;
            if (!string.IsNullOrEmpty(NewPassword))
            {
                user.Password = NewPassword; // Ideally, hash passwords before storing them
            }
            user.IsAdmin = UserRole == "Admin";

            await _context.SaveChangesAsync();
            Console.WriteLine("User edited successfully.");

            // Reload data and redirect
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditApplicationAsync(int applicationId)
        {
            var application = _context.EmployeeApplications.FirstOrDefault(a => a.Id == applicationId);  // Changed to EmployeeApplications
            if (application == null)
            {
                Console.WriteLine("Application not found.");
                Users = _context.Users.ToList();
                Applications = _context.EmployeeApplications.ToList();  // Changed to EmployeeApplications
                ModelState.AddModelError(string.Empty, "Application not found.");
                return Page();
            }

            // Update application details
            application.Status = "Updated"; // Example of updating status
            application.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            Console.WriteLine("Application edited successfully.");

            // Reload data and redirect
            return RedirectToPage();
        }
    }
}
