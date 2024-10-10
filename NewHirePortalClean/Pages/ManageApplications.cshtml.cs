using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewHirePortalClean.Data;
using NewHirePortalClean.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewHirePortalClean.Pages
{
    public class ManageApplicationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManageApplicationsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }
    }
}
