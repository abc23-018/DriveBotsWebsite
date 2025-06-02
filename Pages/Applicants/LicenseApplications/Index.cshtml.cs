using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DriveBotsWebsite.Models;
using DriveBotsWebsite.Services;

namespace DriveBotsWebsite.Pages.Applicants.LicenseApplications
{
    public class IndexModel : PageModel
    {
        private readonly DriveBotsWebsite.Services.ApplicationDbContext _context;

        public IndexModel(DriveBotsWebsite.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LicenseApplication> LicenseApplication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LicenseApplication = await _context.LicenseApplications.ToListAsync();
        }
    }
}
