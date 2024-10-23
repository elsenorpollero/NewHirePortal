using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;  // This ensures the correct User class is used
using System.Threading.Tasks;

namespace NewHirePortalClean.Pages
{
    public class EditUserModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditUserModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NewHirePortalClean.Models.User User { get; set; }  // Specify the full namespace for User

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userToUpdate = await _context.Users.FindAsync(User.Id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Username = User.Username;
            userToUpdate.Password = User.Password;
            userToUpdate.IsAdmin = User.IsAdmin;

            await _context.SaveChangesAsync();

            return RedirectToPage("/AdminPortal");
        }
    }
}
