using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
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
        public User User { get; set; }

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
