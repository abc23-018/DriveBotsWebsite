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
    public class DetailsModel : PageModel
    {
        private readonly DriveBotsWebsite.Services.ApplicationDbContext _context;

        public DetailsModel(DriveBotsWebsite.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public LicenseApplication LicenseApplication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseapplication = await _context.LicenseApplications.FirstOrDefaultAsync(m => m.Id == id);
            if (licenseapplication == null)
            {
                return NotFound();
            }
            else
            {
                LicenseApplication = licenseapplication;
            }
            return Page();
        }
    }
}
