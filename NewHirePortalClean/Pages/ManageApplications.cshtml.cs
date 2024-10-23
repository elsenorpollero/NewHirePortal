using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewHirePortalClean.Pages
{
    public class ManageApplicationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManageApplicationsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<EmployeeApplication> Applications { get; set; }  // Updated to EmployeeApplication

        public void OnGet()
        {
            Applications = _context.EmployeeApplications.ToList();  // Corrected to EmployeeApplications
        }
    }
}
